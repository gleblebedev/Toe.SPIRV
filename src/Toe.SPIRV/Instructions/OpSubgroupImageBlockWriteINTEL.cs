using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupImageBlockWriteINTEL : Instruction
    {
        public override Op OpCode => Op.OpSubgroupImageBlockWriteINTEL;

        public IdRef Image { get; set; }
        public IdRef Coordinate { get; set; }
        public IdRef Data { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Image", Image);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("Data", Data);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Image = IdRef.Parse(reader, end - reader.Position);
            Coordinate = IdRef.Parse(reader, end - reader.Position);
            Data = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Image} {Coordinate} {Data}";
        }
    }
}