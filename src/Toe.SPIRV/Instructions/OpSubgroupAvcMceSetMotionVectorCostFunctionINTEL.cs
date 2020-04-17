using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL: InstructionWithId
    {
        public OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef PackedCostCenterDelta { get; set; }

        public Spv.IdRef PackedCostTable { get; set; }

        public Spv.IdRef CostPrecision { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("PackedCostCenterDelta", PackedCostCenterDelta);
            yield return new ReferenceProperty("PackedCostTable", PackedCostTable);
            yield return new ReferenceProperty("CostPrecision", CostPrecision);
            yield return new ReferenceProperty("Payload", Payload);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            PackedCostCenterDelta = Spv.IdRef.Parse(reader, end-reader.Position);
            PackedCostTable = Spv.IdRef.Parse(reader, end-reader.Position);
            CostPrecision = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += PackedCostCenterDelta.GetWordCount();
            wordCount += PackedCostTable.GetWordCount();
            wordCount += CostPrecision.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            PackedCostCenterDelta.Write(writer);
            PackedCostTable.Write(writer);
            CostPrecision.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {PackedCostCenterDelta} {PackedCostTable} {CostPrecision} {Payload}";
        }
    }
}
