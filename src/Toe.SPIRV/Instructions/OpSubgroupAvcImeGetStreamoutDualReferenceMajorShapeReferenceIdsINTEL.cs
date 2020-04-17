using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Payload { get; set; }

        public Spv.IdRef MajorShape { get; set; }

        public Spv.IdRef Direction { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Payload", Payload);
            yield return new ReferenceProperty("MajorShape", MajorShape);
            yield return new ReferenceProperty("Direction", Direction);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
            MajorShape = Spv.IdRef.Parse(reader, end-reader.Position);
            Direction = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Payload.GetWordCount();
            wordCount += MajorShape.GetWordCount();
            wordCount += Direction.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Payload.Write(writer);
            MajorShape.Write(writer);
            Direction.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Payload} {MajorShape} {Direction}";
        }
    }
}