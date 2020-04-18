using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpAtomicStore: Instruction
    {
        public OpAtomicStore()
        {
        }

        public override Op OpCode { get { return Op.OpAtomicStore; } }

        public Spv.IdRef Pointer { get; set; }

        public uint Memory { get; set; }

        public uint Semantics { get; set; }

        public Spv.IdRef Value { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Memory = Spv.IdScope.Parse(reader, end-reader.Position);
            Semantics = Spv.IdMemorySemantics.Parse(reader, end-reader.Position);
            Value = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Pointer.GetWordCount();
            wordCount += Memory.GetWordCount();
            wordCount += Semantics.GetWordCount();
            wordCount += Value.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Pointer.Write(writer);
            Memory.Write(writer);
            Semantics.Write(writer);
            Value.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Memory} {Semantics} {Value}";
        }
    }
}
