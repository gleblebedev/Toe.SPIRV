using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCapability: Instruction
    {
        public OpCapability()
        {
        }

        public override Op OpCode { get { return Op.OpCapability; } }

        public Spv.Capability Value { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Value = Spv.Capability.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Value.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Value.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Value}";
        }
    }
}
