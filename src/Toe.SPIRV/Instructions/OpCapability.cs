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

        public Spv.Capability Capability { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Capability = Spv.Capability.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Capability.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Capability.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Capability}";
        }
    }
}
