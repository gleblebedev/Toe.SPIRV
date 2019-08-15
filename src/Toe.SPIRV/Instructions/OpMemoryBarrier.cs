using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMemoryBarrier : Instruction
    {
        public override Op OpCode => Op.OpMemoryBarrier;

        public uint Memory { get; set; }
        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Memory = IdScope.Parse(reader, end - reader.Position);
            Semantics = IdMemorySemantics.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Memory} {Semantics}";
        }
    }
}