using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeSetDualReferenceINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeSetDualReferenceINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeSetDualReferenceINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef FwdRefOffset { get; set; }

        public Spv.IdRef BwdRefOffset { get; set; }

        public Spv.IdRef SearchWindowConfig { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("FwdRefOffset", FwdRefOffset);
            yield return new ReferenceProperty("BwdRefOffset", BwdRefOffset);
            yield return new ReferenceProperty("SearchWindowConfig", SearchWindowConfig);
            yield return new ReferenceProperty("Payload", Payload);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            FwdRefOffset = Spv.IdRef.Parse(reader, end-reader.Position);
            BwdRefOffset = Spv.IdRef.Parse(reader, end-reader.Position);
            SearchWindowConfig = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += FwdRefOffset.GetWordCount();
            wordCount += BwdRefOffset.GetWordCount();
            wordCount += SearchWindowConfig.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            FwdRefOffset.Write(writer);
            BwdRefOffset.Write(writer);
            SearchWindowConfig.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {FwdRefOffset} {BwdRefOffset} {SearchWindowConfig} {Payload}";
        }
    }
}
