using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpConstantSampler : InstructionWithId
    {
        public override Op OpCode => Op.OpConstantSampler;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public SamplerAddressingMode SamplerAddressingMode { get; set; }
        public uint Param { get; set; }
        public SamplerFilterMode SamplerFilterMode { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            SamplerAddressingMode = SamplerAddressingMode.Parse(reader, end - reader.Position);
            Param = LiteralInteger.Parse(reader, end - reader.Position);
            SamplerFilterMode = SamplerFilterMode.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SamplerAddressingMode} {Param} {SamplerFilterMode}";
        }
    }
}