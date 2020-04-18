using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpModuleProcessed: Instruction
    {
        public OpModuleProcessed()
        {
        }

        public override Op OpCode { get { return Op.OpModuleProcessed; } }

        public string Process { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Process = Spv.LiteralString.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Process.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Process.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Process}";
        }
    }
}
