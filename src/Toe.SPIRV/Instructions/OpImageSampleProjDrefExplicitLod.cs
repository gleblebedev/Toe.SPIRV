using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpImageSampleProjDrefExplicitLod: InstructionWithId
    {
        public OpImageSampleProjDrefExplicitLod()
        {
        }

        public override Op OpCode { get { return Op.OpImageSampleProjDrefExplicitLod; } }

        public Spv.IdRef<TypeInstruction> IdResultType { get; set; }
        public Spv.IdRef SampledImage { get; set; }
        public Spv.IdRef Coordinate { get; set; }
        public Spv.IdRef D_ref { get; set; }
        public Spv.ImageOperands ImageOperands { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledImage", SampledImage);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("D_ref", D_ref);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SampledImage = Spv.IdRef.Parse(reader, end-reader.Position);
            Coordinate = Spv.IdRef.Parse(reader, end-reader.Position);
            D_ref = Spv.IdRef.Parse(reader, end-reader.Position);
            ImageOperands = Spv.ImageOperands.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SampledImage.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += D_ref.GetWordCount();
            wordCount += ImageOperands.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SampledImage.Write(writer);
            Coordinate.Write(writer);
            D_ref.Write(writer);
            ImageOperands.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SampledImage} {Coordinate} {D_ref} {ImageOperands}";
        }
    }
}
