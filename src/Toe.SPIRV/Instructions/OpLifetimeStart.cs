using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpLifetimeStart: Instruction
    {
        public OpLifetimeStart()
        {
        }

        public override Op OpCode { get { return Op.OpLifetimeStart; } }

        public Spv.IdRef Pointer { get; set; }

        public uint Size { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Size = Spv.LiteralInteger.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Pointer.GetWordCount();
            wordCount += Size.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Pointer.Write(writer);
            Size.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Size}";
        }
    }
}
