using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSourceExtension: Instruction
    {
        public OpSourceExtension()
        {
        }

        public override Op OpCode { get { return Op.OpSourceExtension; } }

        public string Extension { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Extension = Spv.LiteralString.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Extension.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Extension.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Extension}";
        }
    }
}
