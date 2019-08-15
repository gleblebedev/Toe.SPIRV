using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpAtomicFlagClear : Instruction
    {
        public override Op OpCode => Op.OpAtomicFlagClear;

        public IdRef Pointer { get; set; }
        public uint Scope { get; set; }
        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Pointer = IdRef.Parse(reader, end - reader.Position);
            Scope = IdScope.Parse(reader, end - reader.Position);
            Semantics = IdMemorySemantics.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Scope} {Semantics}";
        }
    }
}