using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSelect: InstructionWithId
    {
        public OpSelect()
        {
        }

        public override Op OpCode { get { return Op.OpSelect; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Condition { get; set; }

        public Spv.IdRef Object1 { get; set; }

        public Spv.IdRef Object2 { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Condition = Spv.IdRef.Parse(reader, end-reader.Position);
            Object1 = Spv.IdRef.Parse(reader, end-reader.Position);
            Object2 = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Condition.GetWordCount();
            wordCount += Object1.GetWordCount();
            wordCount += Object2.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Condition.Write(writer);
            Object1.Write(writer);
            Object2.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Condition} {Object1} {Object2}";
        }
    }
}
