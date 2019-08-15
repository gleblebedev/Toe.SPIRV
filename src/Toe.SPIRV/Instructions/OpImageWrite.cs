using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpImageWrite : Instruction
    {
        public override Op OpCode => Op.OpImageWrite;

        public IdRef Image { get; set; }
        public IdRef Coordinate { get; set; }
        public IdRef Texel { get; set; }
        public ImageOperands ImageOperands { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Image", Image);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("Texel", Texel);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Image = IdRef.Parse(reader, end - reader.Position);
            Coordinate = IdRef.Parse(reader, end - reader.Position);
            Texel = IdRef.Parse(reader, end - reader.Position);
            ImageOperands = ImageOperands.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Image} {Coordinate} {Texel} {ImageOperands}";
        }
    }
}