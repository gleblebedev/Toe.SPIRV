using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpPtrAccessChain: InstructionWithId
    {
        public OpPtrAccessChain()
        {
        }

        public override Op OpCode { get { return Op.OpPtrAccessChain; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Base { get; set; }

        public Spv.IdRef Element { get; set; }

        public IList<Spv.IdRef> Indexes { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Base = Spv.IdRef.Parse(reader, end-reader.Position);
            Element = Spv.IdRef.Parse(reader, end-reader.Position);
            Indexes = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Base.GetWordCount();
            wordCount += Element.GetWordCount();
            wordCount += Indexes.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Base.Write(writer);
            Element.Write(writer);
            Indexes.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Base} {Element} {Indexes}";
        }
    }
}
