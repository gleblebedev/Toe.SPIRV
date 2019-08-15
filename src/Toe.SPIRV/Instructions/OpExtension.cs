using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpExtension : Instruction
    {
        public override Op OpCode => Op.OpExtension;

        public string Name { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Name = LiteralString.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Name}";
        }
    }
}