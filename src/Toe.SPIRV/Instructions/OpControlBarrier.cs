using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpControlBarrier : Instruction
    {
        public override Op OpCode => Op.OpControlBarrier;

        public uint Execution { get; set; }
        public uint Memory { get; set; }
        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Execution = IdScope.Parse(reader, end - reader.Position);
            Memory = IdScope.Parse(reader, end - reader.Position);
            Semantics = IdMemorySemantics.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Execution} {Memory} {Semantics}";
        }
    }
}