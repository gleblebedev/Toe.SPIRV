using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcImage { get; set; }

        public Spv.IdRef RefImage { get; set; }

        public Spv.IdRef Payload { get; set; }

        public Spv.IdRef StreaminComponents { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SrcImage", SrcImage);
            yield return new ReferenceProperty("RefImage", RefImage);
            yield return new ReferenceProperty("Payload", Payload);
            yield return new ReferenceProperty("StreaminComponents", StreaminComponents);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SrcImage = Spv.IdRef.Parse(reader, end-reader.Position);
            RefImage = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
            StreaminComponents = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SrcImage.GetWordCount();
            wordCount += RefImage.GetWordCount();
            wordCount += Payload.GetWordCount();
            wordCount += StreaminComponents.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SrcImage.Write(writer);
            RefImage.Write(writer);
            Payload.Write(writer);
            StreaminComponents.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcImage} {RefImage} {Payload} {StreaminComponents}";
        }
    }
}