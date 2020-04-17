using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL: InstructionWithId
    {
        public OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef LumaModePenalty { get; set; }

        public Spv.IdRef LumaPackedNeighborModes { get; set; }

        public Spv.IdRef LumaPackedNonDcPenalty { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("LumaModePenalty", LumaModePenalty);
            yield return new ReferenceProperty("LumaPackedNeighborModes", LumaPackedNeighborModes);
            yield return new ReferenceProperty("LumaPackedNonDcPenalty", LumaPackedNonDcPenalty);
            yield return new ReferenceProperty("Payload", Payload);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            LumaModePenalty = Spv.IdRef.Parse(reader, end-reader.Position);
            LumaPackedNeighborModes = Spv.IdRef.Parse(reader, end-reader.Position);
            LumaPackedNonDcPenalty = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += LumaModePenalty.GetWordCount();
            wordCount += LumaPackedNeighborModes.GetWordCount();
            wordCount += LumaPackedNonDcPenalty.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            LumaModePenalty.Write(writer);
            LumaPackedNeighborModes.Write(writer);
            LumaPackedNonDcPenalty.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {LumaModePenalty} {LumaPackedNeighborModes} {LumaPackedNonDcPenalty} {Payload}";
        }
    }
}
