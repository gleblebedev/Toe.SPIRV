using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSourceContinued : Instruction
    {
        public override Op OpCode => Op.OpSourceContinued;

        public string ContinuedSource { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            ContinuedSource = LiteralString.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {ContinuedSource}";
        }
    }
}