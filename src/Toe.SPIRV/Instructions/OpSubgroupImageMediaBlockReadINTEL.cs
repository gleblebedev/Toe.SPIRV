using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupImageMediaBlockReadINTEL: InstructionWithId
    {
        public OpSubgroupImageMediaBlockReadINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupImageMediaBlockReadINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Image { get; set; }

        public Spv.IdRef Coordinate { get; set; }

        public Spv.IdRef Width { get; set; }

        public Spv.IdRef Height { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Image", Image);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("Width", Width);
            yield return new ReferenceProperty("Height", Height);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Image = Spv.IdRef.Parse(reader, end-reader.Position);
            Coordinate = Spv.IdRef.Parse(reader, end-reader.Position);
            Width = Spv.IdRef.Parse(reader, end-reader.Position);
            Height = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Image.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += Width.GetWordCount();
            wordCount += Height.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Image.Write(writer);
            Coordinate.Write(writer);
            Width.Write(writer);
            Height.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Image} {Coordinate} {Width} {Height}";
        }
    }
}
