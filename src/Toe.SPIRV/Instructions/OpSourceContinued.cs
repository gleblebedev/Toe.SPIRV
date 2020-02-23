using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSourceContinued: Instruction
    {
        public OpSourceContinued()
        {
        }

        public override Op OpCode { get { return Op.OpSourceContinued; } }

        public string ContinuedSource { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            ContinuedSource = Spv.LiteralString.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += ContinuedSource.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            ContinuedSource.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {ContinuedSource}";
        }
    }
}
