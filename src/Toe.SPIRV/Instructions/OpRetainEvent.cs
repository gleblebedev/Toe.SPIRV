using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpRetainEvent: Instruction
    {
        public OpRetainEvent()
        {
        }

        public override Op OpCode { get { return Op.OpRetainEvent; } }

        public Spv.IdRef Event { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Event = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Event.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Event.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Event}";
        }
    }
}
