using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpMemberDecorate: Instruction
    {
        public OpMemberDecorate()
        {
        }

        public override Op OpCode { get { return Op.OpMemberDecorate; } }

        public Spv.IdRef StructureType { get; set; }

        public uint Member { get; set; }

        public Spv.Decoration Decoration { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            StructureType = Spv.IdRef.Parse(reader, end-reader.Position);
            Member = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            Decoration = Spv.Decoration.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += StructureType.GetWordCount();
            wordCount += Member.GetWordCount();
            wordCount += Decoration.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            StructureType.Write(writer);
            Member.Write(writer);
            Decoration.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {StructureType} {Member} {Decoration}";
        }
    }
}
