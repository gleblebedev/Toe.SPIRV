using System;
using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class ShaderReflection
    {
        private readonly Shader _shader;
        List<SpirvStructure> _structures = new List<SpirvStructure>();
        Dictionary<uint, SpirvTypeBase> _types = new Dictionary<uint, SpirvTypeBase>();
        public IReadOnlyList<SpirvStructure> Structures => _structures;

        public ShaderReflection(Shader shader)
        {
            _shader = shader;
            foreach (var instruction in _shader.Instructions)
            {
                switch (instruction.OpCode)
                {
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
                }
            }
        }

    

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
            SpirvArray array;
            if (lengthType == SpirvTypeBase.UInt)
                array = new SpirvArray(_types[instruction.ElementType.Id], length.Value.Value.ToUInt32());
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
            var vector = SpirvTypeBase.ResolveMatrix(columnType, columnCount);
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
            var structure = new SpirvStructure();
            AddType(instruction, structure);
            _structures.Add(structure);
            for (var index = 0; index < instruction.MemberTypes.Count; index++)
            {
                var instructionMemberType = instruction.MemberTypes[index];
                string name = null;
                if (instruction.MemberNames != null && instruction.MemberNames.Count > index)
                {
                    name = instruction.MemberNames[index].Name;
                }
                var byteOffset = instruction.FindMemberDecoration<Decoration.Offset>((uint)index)?.ByteOffset ?? 0;
                structure.Fields.Add(new SpirvStructureField(_types[instructionMemberType.Id], name, byteOffset));
            }
        }
    }
}
