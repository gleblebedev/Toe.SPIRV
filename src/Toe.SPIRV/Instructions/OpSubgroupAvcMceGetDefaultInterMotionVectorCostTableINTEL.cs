using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL: InstructionWithId
    {
        public OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SliceType { get; set; }

        public Spv.IdRef Qp { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SliceType", SliceType);
            yield return new ReferenceProperty("Qp", Qp);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SliceType = Spv.IdRef.Parse(reader, end-reader.Position);
            Qp = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SliceType.GetWordCount();
            wordCount += Qp.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SliceType.Write(writer);
            Qp.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SliceType} {Qp}";
        }
    }
}
