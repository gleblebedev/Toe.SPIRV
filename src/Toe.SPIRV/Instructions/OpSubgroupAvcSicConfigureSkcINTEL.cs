using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcSicConfigureSkcINTEL: InstructionWithId
    {
        public OpSubgroupAvcSicConfigureSkcINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcSicConfigureSkcINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SkipBlockPartitionType { get; set; }

        public Spv.IdRef SkipMotionVectorMask { get; set; }

        public Spv.IdRef MotionVectors { get; set; }

        public Spv.IdRef BidirectionalWeight { get; set; }

        public Spv.IdRef SadAdjustment { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SkipBlockPartitionType", SkipBlockPartitionType);
            yield return new ReferenceProperty("SkipMotionVectorMask", SkipMotionVectorMask);
            yield return new ReferenceProperty("MotionVectors", MotionVectors);
            yield return new ReferenceProperty("BidirectionalWeight", BidirectionalWeight);
            yield return new ReferenceProperty("SadAdjustment", SadAdjustment);
            yield return new ReferenceProperty("Payload", Payload);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SkipBlockPartitionType = Spv.IdRef.Parse(reader, end-reader.Position);
            SkipMotionVectorMask = Spv.IdRef.Parse(reader, end-reader.Position);
            MotionVectors = Spv.IdRef.Parse(reader, end-reader.Position);
            BidirectionalWeight = Spv.IdRef.Parse(reader, end-reader.Position);
            SadAdjustment = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SkipBlockPartitionType.GetWordCount();
            wordCount += SkipMotionVectorMask.GetWordCount();
            wordCount += MotionVectors.GetWordCount();
            wordCount += BidirectionalWeight.GetWordCount();
            wordCount += SadAdjustment.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SkipBlockPartitionType.Write(writer);
            SkipMotionVectorMask.Write(writer);
            MotionVectors.Write(writer);
            BidirectionalWeight.Write(writer);
            SadAdjustment.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SkipBlockPartitionType} {SkipMotionVectorMask} {MotionVectors} {BidirectionalWeight} {SadAdjustment} {Payload}";
        }
    }
}
