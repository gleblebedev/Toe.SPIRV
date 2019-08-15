using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpStore : Instruction
    {
        public override Op OpCode => Op.OpStore;

        public IdRef Pointer { get; set; }
        public IdRef Object { get; set; }
        public MemoryAccess MemoryAccess { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
            yield return new ReferenceProperty("Object", Object);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Pointer = IdRef.Parse(reader, end - reader.Position);
            Object = IdRef.Parse(reader, end - reader.Position);
            MemoryAccess = MemoryAccess.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Object} {MemoryAccess}";
        }
    }
}