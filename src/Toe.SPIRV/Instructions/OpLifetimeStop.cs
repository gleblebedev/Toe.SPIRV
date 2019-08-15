using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpLifetimeStop : Instruction
    {
        public override Op OpCode => Op.OpLifetimeStop;

        public IdRef Pointer { get; set; }
        public uint Size { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Pointer = IdRef.Parse(reader, end - reader.Position);
            Size = LiteralInteger.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Size}";
        }
    }
}