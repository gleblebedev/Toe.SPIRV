using System;
using System.Collections.Generic;
using System.IO;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvInstructionTreeBuilder
    {
        private readonly Dictionary<uint, SpirvTypeBase> _types = new Dictionary<uint, SpirvTypeBase>();
        private readonly Dictionary<uint, Node> _nodeMap = new Dictionary<uint, Node>();
        private readonly List<KeyValuePair<Instruction, Node>> _nodes = new List<KeyValuePair<Instruction, Node>>();
        private Shader _shader;

        public SpirvTypeBase ResolveType(IdRef idRef)
        {
            if (idRef == null)
                return null;
            return _types[idRef.Id];
        }
        public SpirvTypeBase ResolveType(uint id)
        {
            if (_types.TryGetValue(id, out var type))
                return type;
            return null;
        }

        public void AddType(InstructionWithId instruction, SpirvTypeBase type)
        {
            _types.Add(instruction.IdResult, type);
        }
        public void ParseFloat(Instruction instruction)
        {
            var opTypeFloat = (OpTypeFloat)instruction;
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

        public void ParseInt(Instruction instruction)
        {
            var opTypeInt = (OpTypeInt)instruction;
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

        public void ParseArray(OpTypeArray instruction)
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
                    new SpirvArray(_types[instruction.ElementType.Id], (uint)length.Value.Value.ToInt32()),
                    arrayStrideValue);
            else
                throw new NotImplementedException();
            AddType(instruction, array);
        }


        public void ParseMatrix(OpTypeMatrix instruction)
        {
            var columnType = _types[instruction.ColumnType.Id];
            var columnCount = instruction.ColumnCount;
            var vector = SpirvTypeBase.ResolveMatrix((SpirvVector)columnType, columnCount);
            AddType(instruction, vector);
        }

        public void ParseVector(OpTypeVector instruction)
        {
            var componentType = _types[instruction.ComponentType.Id];
            var instructionComponentCount = instruction.ComponentCount;
            var vector = SpirvTypeBase.ResolveVector(componentType, instructionComponentCount);
            AddType(instruction, vector);
        }

        public void ParseStructure(OpTypeStruct instruction)
        {
            var fields = new SpirvStructureField[instruction.MemberTypes.Count];
            for (var index = 0; index < instruction.MemberTypes.Count; index++)
            {
                var instructionMemberType = instruction.MemberTypes[index];
                string name = null;
                if (instruction.MemberNames != null && instruction.MemberNames.Count > index)
                    name = instruction.MemberNames[index].Name;
                var byteOffset = instruction.FindMemberDecoration<Decoration.Offset>((uint)index)?.ByteOffset;
                var spirvTypeBase = _types[instructionMemberType.Id];
                if (spirvTypeBase.TypeCategory == SpirvTypeCategory.Array)
                {
                    var arrayStride = instruction.FindMemberDecoration<Decoration.ArrayStride>((uint)index)
                        ?.ArrayStrideValue;
                    spirvTypeBase = new SpirvArrayLayout((SpirvArrayBase)spirvTypeBase, arrayStride);
                }
                else if (spirvTypeBase.TypeCategory == SpirvTypeCategory.Matrix)
                {
                    var matrixStride = instruction.FindMemberDecoration<Decoration.MatrixStride>((uint)index)
                        ?.MatrixStrideValue;
                    var rowMajor = instruction.FindMemberDecoration((uint)index, Decoration.Enumerant.RowMajor) !=
                                   null;
                    var colMajor = instruction.FindMemberDecoration((uint)index, Decoration.Enumerant.ColMajor) !=
                                   null;
                    var matrixOrientation = MatrixOrientation.ColMajor;
                    if (rowMajor && colMajor)
                        throw new InvalidDataException("Matrix can't have both ColMajor and RowMajor declarations");
                    if (rowMajor)
                        matrixOrientation = MatrixOrientation.RowMajor;
                    else if (colMajor)
                        matrixOrientation = MatrixOrientation.ColMajor;
                    spirvTypeBase =
                        new SpirvMatrixLayout((SpirvMatrixBase)spirvTypeBase, matrixOrientation, matrixStride);
                }

                fields[index] = new SpirvStructureField(spirvTypeBase, name, byteOffset);
            }

            Array.Sort(fields);
            var structure = new SpirvStructure(instruction.OpName?.Name, fields);
            AddType(instruction, structure);
        }

        public void ParseFunctionType(OpTypeFunction instruction)
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

        public void ParsePointerType(OpTypePointer instruction)
        {
            var function = new SpirvPointerType();
            function.Name = instruction.OpName?.Name;
            function.Type = ResolveType(instruction.Type);
            function.StorageClass = instruction.StorageClass.Value;
            AddType(instruction, function);
        }

        public void RegisterNodeResult(uint id, Node node)
        {
            _nodeMap.Add(id, node);
        }

        public Node GetNode(IdRef id)
        {
            if (id == null)
                return null;
            return _nodeMap[id.Id];
        }

        public IList<Node> GetNodes(IList<IdRef> ids)
        {
            var nodes = new List<Node>();
            if (ids != null)
            {
                foreach (var idRef in ids)
                {
                    nodes.Add(GetNode(idRef));
                }
            }

            return nodes;
        }

        public void BuildTree(Shader shader)
        {
            _shader = shader;
            OpEntryPoint entryPoint = null;
            for (var index = 0; index < _shader.Instructions.Count; index++)
            {
                var instruction = _shader.Instructions[index];
                switch (instruction.OpCode)
                {
                    case Op.OpCapability:
                    case Op.OpExtInstImport:
                    case Op.OpExtInst:
                    case Op.OpMemoryModel:
                    case Op.OpString:
                    case Op.OpSource:
                    case Op.OpSourceExtension:
                    case Op.OpName:
                    case Op.OpDecorate:
                    case Op.OpMemberName:
                    case Op.OpLine:
                    case Op.OpMemberDecorate:
                        break;
                    case Op.OpTypeVector:
                        ParseVector((OpTypeVector)instruction);
                        break;
                    case Op.OpTypeStruct:
                        ParseStructure((OpTypeStruct)instruction);
                        break;
                    case Op.OpTypeMatrix:
                        ParseMatrix((OpTypeMatrix)instruction);
                        break;
                    case Op.OpTypeArray:
                        ParseArray((OpTypeArray)instruction);
                        break;
                    case Op.OpTypeFloat:
                        ParseFloat(instruction);
                        break;
                    case Op.OpTypeBool:
                        AddType((InstructionWithId)instruction, SpirvTypeBase.Bool);
                        break;
                    case Op.OpTypeVoid:
                        AddType((InstructionWithId)instruction, SpirvTypeBase.Void);
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
                    case Op.OpTypePointer:
                        ParsePointerType((OpTypePointer)instruction);
                        break;
                    case Op.OpFunction:
                        {
                            var function = ParseNode(instruction);
                            var hasId = _shader.Instructions[index].TryGetResultId(out var id);
                            if (hasId)
                            {
                                if (entryPoint != null && id == entryPoint.EntryPoint.Id)
                                {
                                    EntryFunction = (Function)function;
                                }
                            }

                            //var hasId = _shader.Instructions[index].TryGetResultId(out var id);
                            //var function = ParseFunctionDefinition(ref index);
                            //if (hasId)
                            //{
                            //    if (entryPoint != null && id == entryPoint.EntryPoint.Id)
                            //    {
                            //        EntryFunction = function;
                            //    }
                            //}
                            break;
                        }
                    default:
                        ParseNode(instruction);
                        break;
                }
            }
            // Fix forward references.
            ExecutableNode prevSequentialInstruction = null;
            foreach (var instructionAndNode in _nodes)
            {
                var key = instructionAndNode.Key;
                var value = instructionAndNode.Value;
                value.SetUp(key, this);
                if (!value.IsFunction && value is ExecutableNode sequential)
                {
                    if (prevSequentialInstruction != null)
                        prevSequentialInstruction.Next = sequential;
                    if (key.OpCode == Op.OpBranch || key.OpCode == Op.OpBranchConditional ||
                        key.OpCode == Op.OpReturn || key.OpCode == Op.OpReturnValue || key.OpCode == Op.OpSwitch ||
                        key.OpCode == Op.OpKill || key.OpCode == Op.OpUnreachable)
                    {
                        prevSequentialInstruction = null;
                    }
                    else
                    {
                        prevSequentialInstruction = sequential;
                    }
                }
            }
        }

        public Function EntryFunction { get; set; }
        public IEnumerable<SpirvTypeBase> Types => _types.Values;

        //private SpirvFunction ParseFunctionDefinition(ref int index)
        //{
        //    var instruction = (OpFunction)_shader.Instructions[index];
        //    var type = (SpirvFunctionType)ResolveType(instruction.FunctionType);
        //    var spirvFunction = new SpirvFunction();
        //    AddNode(instruction, spirvFunction);
        //    RegisterNodeResult(instruction.IdResult, spirvFunction);
        //    spirvFunction.ReturnType = type.ReturnType;
        //    spirvFunction.FunctionControl = (FunctionControl)instruction.FunctionControl.Value;
        //    ++index;

        //    // Parse arguments.
        //    foreach (var argument in type.Arguments)
        //    {
        //        if (_shader.Instructions.Count <= index)
        //            throw new IndexOutOfRangeException("Expected OpFunctionParameter at index " + index);
        //        if (_shader.Instructions[index].OpCode != Op.OpFunctionParameter)
        //            throw new ArgumentException("Expected OpFunctionParameter at index " + index);
        //        spirvFunction.Arguments.Add(ParseFunctionParameter(argument, (OpFunctionParameter)_shader.Instructions[index]));
        //        ++index;
        //    }

        //    // Create nodes.
        //    while (index < _shader.Instructions.Count)
        //    {
        //        var op = _shader.Instructions[index];
        //        if (op.OpCode == Op.OpFunctionEnd)
        //            break;
        //        var node = ParseNode(op);
        //        if (node != null)
        //        {
        //            _nodes.Add(new KeyValuePair<Instruction, Node>(op, node));
        //        }

        //        ++index;
        //    }

        //    return spirvFunction;
        //}

        private void AddNode(Instruction instruction, Node node)
        {
            _nodes.Add(new KeyValuePair<Instruction, Node>(instruction, node));
        }

        private Node ParseNode(Instruction op)
        {
            Node node = Node.Create(op, this);
            if (node != null)
            {
                if (op.TryGetResultId(out var id))
                {
                    RegisterNodeResult(id, node);
                }

                AddNode(op, node);
            }

            return node;
        }

        //private FunctionParameter ParseFunctionParameter(SpirvFunctionArgument argument, OpFunctionParameter parameter)
        //{
        //    var node = (FunctionParameter)ParseNode(parameter);
        //    if (node.ReturnType != argument.Type)
        //    {
        //        throw new ArgumentException("Argument type mismatch: expected " + argument.Type + " but parameter type is " + node.ReturnType);
        //    }
        //    return node;
        //}

    }
}