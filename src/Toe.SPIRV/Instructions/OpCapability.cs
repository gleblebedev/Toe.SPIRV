using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpCapability : Instruction
    {
        public override Op OpCode => Op.OpCapability;

        public Capability Capability { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Capability = Capability.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Capability}";
        }
    }
}