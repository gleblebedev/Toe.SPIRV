using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpVectorShuffle: InstructionWithId
    {
        public OpVectorShuffle()
        {
        }

        public override Op OpCode { get { return Op.OpVectorShuffle; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Vector1 { get; set; }

        public Spv.IdRef Vector2 { get; set; }

        public IList<uint> Components { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Vector1 = Spv.IdRef.Parse(reader, end-reader.Position);
            Vector2 = Spv.IdRef.Parse(reader, end-reader.Position);
            Components = Spv.LiteralInteger.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Vector1.GetWordCount();
            wordCount += Vector2.GetWordCount();
            wordCount += Components.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Vector1.Write(writer);
            Vector2.Write(writer);
            Components.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Vector1} {Vector2} {Components}";
        }
    }
}
