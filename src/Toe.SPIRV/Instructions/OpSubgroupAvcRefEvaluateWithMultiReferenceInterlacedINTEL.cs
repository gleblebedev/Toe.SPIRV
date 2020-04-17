using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL: InstructionWithId
    {
        public OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcImage { get; set; }

        public Spv.IdRef PackedReferenceIds { get; set; }

        public Spv.IdRef PackedReferenceFieldPolarities { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SrcImage", SrcImage);
            yield return new ReferenceProperty("PackedReferenceIds", PackedReferenceIds);
            yield return new ReferenceProperty("PackedReferenceFieldPolarities", PackedReferenceFieldPolarities);
            yield return new ReferenceProperty("Payload", Payload);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SrcImage = Spv.IdRef.Parse(reader, end-reader.Position);
            PackedReferenceIds = Spv.IdRef.Parse(reader, end-reader.Position);
            PackedReferenceFieldPolarities = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SrcImage.GetWordCount();
            wordCount += PackedReferenceIds.GetWordCount();
            wordCount += PackedReferenceFieldPolarities.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SrcImage.Write(writer);
            PackedReferenceIds.Write(writer);
            PackedReferenceFieldPolarities.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcImage} {PackedReferenceIds} {PackedReferenceFieldPolarities} {Payload}";
        }
    }
}
