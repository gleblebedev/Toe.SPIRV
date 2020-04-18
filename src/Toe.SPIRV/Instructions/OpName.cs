using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpName: Instruction
    {
        public OpName()
        {
        }

        public override Op OpCode { get { return Op.OpName; } }

        public Spv.IdRef Target { get; set; }

        public string Value { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Target = Spv.IdRef.Parse(reader, end-reader.Position);
            Value = Spv.LiteralString.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Target.GetWordCount();
            wordCount += Value.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Target.Write(writer);
            Value.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Target} {Value}";
        }
    }
}
