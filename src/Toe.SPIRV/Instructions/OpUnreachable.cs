using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpUnreachable: Instruction
    {
        public OpUnreachable()
        {
        }

        public override Op OpCode { get { return Op.OpUnreachable; } }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
        }

        public override string ToString()
        {
            return $"{OpCode} ";
        }
    }
}
