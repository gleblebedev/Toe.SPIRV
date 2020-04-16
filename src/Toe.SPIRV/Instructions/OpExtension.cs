using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpExtension: Instruction
    {
        public OpExtension()
        {
        }

        public override Op OpCode { get { return Op.OpExtension; } }

        public string Name { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Name = Spv.LiteralString.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Name.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Name.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Name}";
        }
    }
}
