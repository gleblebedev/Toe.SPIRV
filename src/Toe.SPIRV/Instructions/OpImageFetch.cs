using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpImageFetch: InstructionWithId
    {
        public OpImageFetch()
        {
        }

        public override Op OpCode { get { return Op.OpImageFetch; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Image { get; set; }

        public Spv.IdRef Coordinate { get; set; }

        public Spv.ImageOperands ImageOperands { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Image = Spv.IdRef.Parse(reader, end-reader.Position);
            Coordinate = Spv.IdRef.Parse(reader, end-reader.Position);
            ImageOperands = Spv.ImageOperands.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Image.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += ImageOperands?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Image.Write(writer);
            Coordinate.Write(writer);
            if (ImageOperands != null) ImageOperands.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Image} {Coordinate} {ImageOperands}";
        }
    }
}
