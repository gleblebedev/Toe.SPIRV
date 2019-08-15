using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpNop : Instruction
    {
        public override Op OpCode => Op.OpNop;

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
        }

        public override string ToString()
        {
            return $"{OpCode} ";
        }
    }
}