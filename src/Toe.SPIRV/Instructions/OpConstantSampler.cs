using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpConstantSampler: InstructionWithId
    {
        public OpConstantSampler()
        {
        }

        public override Op OpCode { get { return Op.OpConstantSampler; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.SamplerAddressingMode SamplerAddressingMode { get; set; }

        public uint Param { get; set; }

        public Spv.SamplerFilterMode SamplerFilterMode { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SamplerAddressingMode = Spv.SamplerAddressingMode.Parse(reader, end-reader.Position);
            Param = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            SamplerFilterMode = Spv.SamplerFilterMode.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SamplerAddressingMode.GetWordCount();
            wordCount += Param.GetWordCount();
            wordCount += SamplerFilterMode.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SamplerAddressingMode.Write(writer);
            Param.Write(writer);
            SamplerFilterMode.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SamplerAddressingMode} {Param} {SamplerFilterMode}";
        }
    }
}
