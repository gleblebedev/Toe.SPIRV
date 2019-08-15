using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupShuffleDownINTEL : InstructionWithId
    {
        public override Op OpCode => Op.OpSubgroupShuffleDownINTEL;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Current { get; set; }
        public IdRef Next { get; set; }
        public IdRef Delta { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Current", Current);
            yield return new ReferenceProperty("Next", Next);
            yield return new ReferenceProperty("Delta", Delta);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Current = IdRef.Parse(reader, end - reader.Position);
            Next = IdRef.Parse(reader, end - reader.Position);
            Delta = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Current} {Next} {Delta}";
        }
    }
}