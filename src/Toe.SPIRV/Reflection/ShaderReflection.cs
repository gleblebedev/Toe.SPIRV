using System;
using System.Collections.Generic;
using System.IO;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class ShaderReflection
    {
        private readonly Shader _shader;
        private readonly List<SpirvStructure> _structures = new List<SpirvStructure>();
        private readonly Dictionary<uint, SpirvTypeBase> _types = new Dictionary<uint, SpirvTypeBase>();

        public ShaderReflection(Shader shader)
        {
            _shader = shader;
            OpEntryPoint entryPoint = null;
            SpirvFunction entryFunction = null;
            foreach (var instruction in _shader.Instructions)
                switch (instruction.OpCode)
                {
                    case Op.OpTypeVector:
                        ParseVector((OpTypeVector) instruction);
                        break;
                    case Op.OpTypeStruct:
                        ParseStructure((OpTypeStruct) instruction);
                        break;
                    case Op.OpTypeMatrix:
                        ParseMatrix((OpTypeMatrix) instruction);
                        break;
                    case Op.OpTypeArray:
                        ParseArray((OpTypeArray) instruction);
                        break;
                    case Op.OpTypeFloat:
                        ParseFloat(instruction);
                        break;
                    case Op.OpTypeBool:
                        AddType((InstructionWithId) instruction, SpirvTypeBase.Bool);
                        break;
                    case Op.OpTypeVoid:
                        AddType((InstructionWithId) instruction, SpirvTypeBase.Void);
                        break;
                    case Op.OpTypeInt:
                        ParseInt(instruction);
                        break;
                    case Op.OpEntryPoint:
                        entryPoint = (OpEntryPoint)instruction;
                        break;
                    case Op.OpTypeFunction:
                        ParseFunctionType((OpTypeFunction)instruction);
                        break;
                    case Op.OpFunction:
                    {
                        var opFunction = (OpFunction) instruction;
                        var function = ParseFunction(opFunction);
                        if (entryPoint != null && opFunction.IdResult == entryPoint.EntryPoint.Id)
                        {
                            entryFunction = function;
                        }
                        break;
                    }
                }
        }

        private SpirvFunction ParseFunction(OpFunction instruction)
        {
            var type = (SpirvFunctionType)ResolveType(instruction.FunctionType);
            var spirvFunction = new SpirvFunction();
            spirvFunction.ReturnType = type.ReturnType;
            foreach (var argument in type.Arguments)
            {
                spirvFunction.Arguments.Add(argument);
            }
            return spirvFunction;
        }

        private SpirvTypeBase ResolveType(IdRef idRef)
        {
            if (idRef == null)
                return null;
            return _types[idRef.Id];
        }
        private SpirvTypeBase ResolveType(uint id)
        {
            if (_types.TryGetValue(id, out var type))
                return type;
            return null;
        }

        private void ParseFunctionType(OpTypeFunction instruction)
        {
            var function = new SpirvFunctionType();
            function.Name = instruction.OpName?.Name;
            function.ReturnType = ResolveType(instruction.ReturnType);
            foreach (var parameterType in instruction.ParameterTypes)
            {
                function.Arguments.Add(new SpirvFunctionArgument(ResolveType(parameterType.Id)));
            }
            AddType(instruction, function);
        }

        public IReadOnlyList<SpirvStructure> Structures => _structures;


        private void ParseFloat(Instruction instruction)
        {
            var opTypeFloat = (OpTypeFloat) instruction;
            switch (opTypeFloat.Width)
            {
                case 16:
                    AddType(opTypeFloat, SpirvTypeBase.Half);
                    break;
                case 32:
                    AddType(opTypeFloat, SpirvTypeBase.Float);
                    break;
                case 64:
                    AddType(opTypeFloat, SpirvTypeBase.Double);
                    break;
            }
        }

        private void ParseInt(Instruction instruction)
        {
            var opTypeInt = (OpTypeInt) instruction;
            switch (opTypeInt.Width)
            {
                case 32:
                    if (opTypeInt.Signedness == 0)
                        AddType(opTypeInt, SpirvTypeBase.UInt);
                    else
                        AddType(opTypeInt, SpirvTypeBase.Int);
                    break;
                case 16:
                    if (opTypeInt.Signedness == 0)
                        AddType(opTypeInt, SpirvTypeBase.UShort);
                    else
                        AddType(opTypeInt, SpirvTypeBase.Short);
                    break;
                case 8:
                    if (opTypeInt.Signedness == 0)
                        AddType(opTypeInt, SpirvTypeBase.Byte);
                    else
                        AddType(opTypeInt, SpirvTypeBase.SByte);
                    break;
            }
        }

        private void ParseArray(OpTypeArray instruction)
        {
            var length = instruction.Length.Instruction as OpConstant;
            var lengthType = _types[length.IdResultType.Id];
            SpirvArrayLayout array;
            var arrayStrideValue = instruction.FindDecoration<Decoration.ArrayStride>()?.ArrayStrideValue;
            if (lengthType == SpirvTypeBase.UInt)
                array = new SpirvArrayLayout(
                    new SpirvArray(_types[instruction.ElementType.Id], length.Value.Value.ToUInt32()),
                    arrayStrideValue);
            else if (lengthType == SpirvTypeBase.Int)
                array = new SpirvArrayLayout(
                    new SpirvArray(_types[instruction.ElementType.Id], (uint) length.Value.Value.ToInt32()),
                    arrayStrideValue);
            else
                throw new NotImplementedException();
            AddType(instruction, array);
        }

        private void AddType(InstructionWithId instruction, SpirvTypeBase type)
        {
            _types.Add(instruction.IdResult, type);
        }

        private void ParseMatrix(OpTypeMatrix instruction)
        {
            var columnType = _types[instruction.ColumnType.Id];
            var columnCount = instruction.ColumnCount;
            var vector = SpirvTypeBase.ResolveMatrix((SpirvVector)columnType, columnCount);
            AddType(instruction, vector);
        }

        private void ParseVector(OpTypeVector instruction)
        {
            var componentType = _types[instruction.ComponentType.Id];
            var instructionComponentCount = instruction.ComponentCount;
            var vector = SpirvTypeBase.ResolveVector(componentType, instructionComponentCount);
            AddType(instruction, vector);
        }

        private void ParseStructure(OpTypeStruct instruction)
        {
            var fields = new SpirvStructureField[instruction.MemberTypes.Count];
            for (var index = 0; index < instruction.MemberTypes.Count; index++)
            {
                var instructionMemberType = instruction.MemberTypes[index];
                string name = null;
                if (instruction.MemberNames != null && instruction.MemberNames.Count > index)
                    name = instruction.MemberNames[index].Name;
                var byteOffset = instruction.FindMemberDecoration<Decoration.Offset>((uint) index)?.ByteOffset;
                var spirvTypeBase = _types[instructionMemberType.Id];
                if (spirvTypeBase.TypeCategory == SpirvTypeCategory.Array)
                {
                    var arrayStride = instruction.FindMemberDecoration<Decoration.ArrayStride>((uint) index)
                        ?.ArrayStrideValue;
                    spirvTypeBase = new SpirvArrayLayout((SpirvArrayBase) spirvTypeBase, arrayStride);
                }
                else if (spirvTypeBase.TypeCategory == SpirvTypeCategory.Matrix)
                {
                    var matrixStride = instruction.FindMemberDecoration<Decoration.MatrixStride>((uint) index)
                        ?.MatrixStrideValue;
                    var rowMajor = instruction.FindMemberDecoration((uint) index, Decoration.Enumerant.RowMajor) !=
                                   null;
                    var colMajor = instruction.FindMemberDecoration((uint) index, Decoration.Enumerant.ColMajor) !=
                                   null;
                    var matrixOrientation = MatrixOrientation.ColMajor;
                    if (rowMajor && colMajor)
                        throw new InvalidDataException("Matrix can't have both ColMajor and RowMajor declarations");
                    if (rowMajor)
                        matrixOrientation = MatrixOrientation.RowMajor;
                    else if (colMajor)
                        matrixOrientation = MatrixOrientation.ColMajor;
                    spirvTypeBase =
                        new SpirvMatrixLayout((SpirvMatrixBase) spirvTypeBase, matrixOrientation, matrixStride);
                }

                fields[index] = new SpirvStructureField(spirvTypeBase, name, byteOffset);
            }

            Array.Sort(fields);
            var structure = new SpirvStructure(instruction.OpName?.Name, fields);
            AddType(instruction, structure);
            _structures.Add(structure);
        }

        public Shader Build()
        {
            var shader = new Shader();
            shader.Instructions.Add(new OpCapability(){Capability = new Capability.Shader() });
            shader.Instructions.Add(new OpExtInstImport(){Name = "GLSL.std.450" });
            shader.Instructions.Add(new OpMemoryModel() { MemoryModel = new MemoryModel.GLSL450(), AddressingModel = new AddressingModel.Logical()});
            //shader.Instructions.Add(new OpEntryPoint() { ExecutionModel = });
            throw new NotImplementedException();
            return shader;
        }
    }
}