using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeSetMaxMotionVectorCountINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeSetMaxMotionVectorCountINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeSetMaxMotionVectorCountINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef MaxMotionVectorCount { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("MaxMotionVectorCount", MaxMotionVectorCount);
            yield return new ReferenceProperty("Payload", Payload);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            MaxMotionVectorCount = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += MaxMotionVectorCount.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            MaxMotionVectorCount.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {MaxMotionVectorCount} {Payload}";
        }
    }
}
