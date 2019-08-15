using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpCopyMemory : Instruction
    {
        public override Op OpCode => Op.OpCopyMemory;

        public IdRef Target { get; set; }
        public IdRef Source { get; set; }
        public MemoryAccess MemoryAccess { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Target", Target);
            yield return new ReferenceProperty("Source", Source);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Target = IdRef.Parse(reader, end - reader.Position);
            Source = IdRef.Parse(reader, end - reader.Position);
            MemoryAccess = MemoryAccess.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Target} {Source} {MemoryAccess}";
        }
    }
}