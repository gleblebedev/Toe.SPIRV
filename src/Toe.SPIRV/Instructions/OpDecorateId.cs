using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpDecorateId : Instruction
    {
        public override Op OpCode => Op.OpDecorateId;

        public IdRef Target { get; set; }
        public Decoration Decoration { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Target", Target);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Target = IdRef.Parse(reader, end - reader.Position);
            Decoration = Decoration.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Target} {Decoration}";
        }
    }
}