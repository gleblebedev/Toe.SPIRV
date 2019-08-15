using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpName : Instruction
    {
        public override Op OpCode => Op.OpName;

        public IdRef Target { get; set; }
        public string Name { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Target", Target);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Target = IdRef.Parse(reader, end - reader.Position);
            Name = LiteralString.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Target} {Name}";
        }
    }
}