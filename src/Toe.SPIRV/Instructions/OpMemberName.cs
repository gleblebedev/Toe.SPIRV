using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpMemberName: Instruction
    {
        public OpMemberName()
        {
        }

        public override Op OpCode { get { return Op.OpMemberName; } }

        public Spv.IdRef Type { get; set; }

        public uint Member { get; set; }

        public string Name { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Type = Spv.IdRef.Parse(reader, end-reader.Position);
            Member = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            Name = Spv.LiteralString.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Type.GetWordCount();
            wordCount += Member.GetWordCount();
            wordCount += Name.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Type.Write(writer);
            Member.Write(writer);
            Name.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Type} {Member} {Name}";
        }
    }
}
