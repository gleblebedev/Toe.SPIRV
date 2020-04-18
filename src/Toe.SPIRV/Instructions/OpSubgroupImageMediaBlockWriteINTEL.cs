using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupImageMediaBlockWriteINTEL: Instruction
    {
        public OpSubgroupImageMediaBlockWriteINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupImageMediaBlockWriteINTEL; } }

        public Spv.IdRef Image { get; set; }

        public Spv.IdRef Coordinate { get; set; }

        public Spv.IdRef Width { get; set; }

        public Spv.IdRef Height { get; set; }

        public Spv.IdRef Data { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Image = Spv.IdRef.Parse(reader, end-reader.Position);
            Coordinate = Spv.IdRef.Parse(reader, end-reader.Position);
            Width = Spv.IdRef.Parse(reader, end-reader.Position);
            Height = Spv.IdRef.Parse(reader, end-reader.Position);
            Data = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Image.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += Width.GetWordCount();
            wordCount += Height.GetWordCount();
            wordCount += Data.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Image.Write(writer);
            Coordinate.Write(writer);
            Width.Write(writer);
            Height.Write(writer);
            Data.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Image} {Coordinate} {Width} {Height} {Data}";
        }
    }
}
