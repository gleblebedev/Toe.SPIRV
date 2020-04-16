using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpLine: Instruction
    {
        public OpLine()
        {
        }

        public override Op OpCode { get { return Op.OpLine; } }

        public Spv.IdRef File { get; set; }

        public uint Value { get; set; }

        public uint Column { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("File", File);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            File = Spv.IdRef.Parse(reader, end-reader.Position);
            Value = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            Column = Spv.LiteralInteger.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += File.GetWordCount();
            wordCount += Value.GetWordCount();
            wordCount += Column.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            File.Write(writer);
            Value.Write(writer);
            Column.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {File} {Value} {Column}";
        }
    }
}
