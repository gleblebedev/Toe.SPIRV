using System;
using System.Collections.Generic;
using System.Text;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class ShaderReflection
    {
        private readonly Shader _shader;
        List<SpirvStructure> _structures = new List<SpirvStructure>();
        Dictionary<uint, SpirvType> _types = new Dictionary<uint, SpirvType>();
        private IReadOnlyList<SpirvStructure> Structures => _structures;

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
                    case Op.OpTypeArray:
                        ParseArray((OpTypeArray)instruction);
                        break;
                    case Op.OpTypeFloat:
                        var opTypeFloat = (OpTypeFloat)instruction;
                        switch (opTypeFloat.Width)
                        {
                            case 16:
                                AddType(opTypeFloat, SpirvType.Half);
                                break;
                            case 32:
                                AddType(opTypeFloat, SpirvType.Float);
                                break;
                            case 64:
                                AddType(opTypeFloat, SpirvType.Double);
                                break;
                        }
                        break;
                    case Op.OpTypeBool:
                        AddType((InstructionWithId)instruction, SpirvType.Bool);
                        break;
                    case Op.OpTypeVoid:
                        AddType((InstructionWithId)instruction, SpirvType.Bool);
                        break;
                    case Op.OpTypeInt:
                        var opTypeInt = (OpTypeInt)instruction;
                        switch (opTypeInt.Width)
                        {
                            case 32:
                                if (opTypeInt.Signedness == 0)
                                    AddType(opTypeInt, SpirvType.UInt);
                                else
                                    AddType(opTypeInt, SpirvType.Int);
                                break;
                        }
                        break;
                }
            }
        }

        private void ParseArray(OpTypeArray instruction)
        {
            var length = instruction.Length.Instruction as OpConstant;
            var lengthType = _types[length.IdResultType.Id];
            SpirvArray array;
            if (lengthType == SpirvType.UInt)
                array = new SpirvArray(_types[instruction.ElementType.Id], length.Value.Value.ToUInt32());
            else
                throw new NotImplementedException();
            AddType(instruction, array);
        }

        private void AddType(InstructionWithId instruction, SpirvType type)
        {
            _types.Add(instruction.IdResult, type);
        }

        private void ParseVector(OpTypeVector instruction)
        {
            var componentType = _types[instruction.ComponentType.Id];
            var instructionComponentCount = instruction.ComponentCount;
            var vector = new SpirvVector(instructionComponentCount, componentType);
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
                structure.Fields.Add(new SpirvStructureField(_types[instructionMemberType.Id], name));
            }
        }
    }
}
