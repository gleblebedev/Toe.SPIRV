using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpImageWrite: Instruction
    {
        public OpImageWrite()
        {
        }

        public override Op OpCode { get { return Op.OpImageWrite; } }

        public Spv.IdRef Image { get; set; }

        public Spv.IdRef Coordinate { get; set; }

        public Spv.IdRef Texel { get; set; }

        public Spv.ImageOperands ImageOperands { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Image", Image);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("Texel", Texel);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Image = Spv.IdRef.Parse(reader, end-reader.Position);
            Coordinate = Spv.IdRef.Parse(reader, end-reader.Position);
            Texel = Spv.IdRef.Parse(reader, end-reader.Position);
            ImageOperands = Spv.ImageOperands.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Image.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += Texel.GetWordCount();
            wordCount += ImageOperands?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Image.Write(writer);
            Coordinate.Write(writer);
            Texel.Write(writer);
            if (ImageOperands != null) ImageOperands.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Image} {Coordinate} {Texel} {ImageOperands}";
        }
    }
}
