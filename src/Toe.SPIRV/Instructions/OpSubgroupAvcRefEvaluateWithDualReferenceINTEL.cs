using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcRefEvaluateWithDualReferenceINTEL: InstructionWithId
    {
        public OpSubgroupAvcRefEvaluateWithDualReferenceINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcRefEvaluateWithDualReferenceINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcImage { get; set; }

        public Spv.IdRef FwdRefImage { get; set; }

        public Spv.IdRef BwdRefImage { get; set; }

        public Spv.IdRef Payload { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SrcImage", SrcImage);
            yield return new ReferenceProperty("FwdRefImage", FwdRefImage);
            yield return new ReferenceProperty("BwdRefImage", BwdRefImage);
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
            FwdRefImage = Spv.IdRef.Parse(reader, end-reader.Position);
            BwdRefImage = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SrcImage.GetWordCount();
            wordCount += FwdRefImage.GetWordCount();
            wordCount += BwdRefImage.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SrcImage.Write(writer);
            FwdRefImage.Write(writer);
            BwdRefImage.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcImage} {FwdRefImage} {BwdRefImage} {Payload}";
        }
    }
}
