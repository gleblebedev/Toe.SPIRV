using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpImageSampleFootprintNV: InstructionWithId
    {
        public OpImageSampleFootprintNV()
        {
        }

        public override Op OpCode { get { return Op.OpImageSampleFootprintNV; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SampledImage { get; set; }

        public Spv.IdRef Coordinate { get; set; }

        public Spv.IdRef Granularity { get; set; }

        public Spv.IdRef Coarse { get; set; }

        public Spv.ImageOperands ImageOperands { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledImage", SampledImage);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("Granularity", Granularity);
            yield return new ReferenceProperty("Coarse", Coarse);
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
            Granularity = Spv.IdRef.Parse(reader, end-reader.Position);
            Coarse = Spv.IdRef.Parse(reader, end-reader.Position);
            ImageOperands = Spv.ImageOperands.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SampledImage.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += Granularity.GetWordCount();
            wordCount += Coarse.GetWordCount();
            wordCount += ImageOperands?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SampledImage.Write(writer);
            Coordinate.Write(writer);
            Granularity.Write(writer);
            Coarse.Write(writer);
            if (ImageOperands != null) ImageOperands.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SampledImage} {Coordinate} {Granularity} {Coarse} {ImageOperands}";
        }
    }
}