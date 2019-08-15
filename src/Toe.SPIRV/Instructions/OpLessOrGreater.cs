using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpLessOrGreater : InstructionWithId
    {
        public override Op OpCode => Op.OpLessOrGreater;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef x { get; set; }
        public IdRef y { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("x", x);
            yield return new ReferenceProperty("y", y);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            x = IdRef.Parse(reader, end - reader.Position);
            y = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {x} {y}";
        }
    }
}