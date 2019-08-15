using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupShuffleUpINTEL : InstructionWithId
    {
        public override Op OpCode => Op.OpSubgroupShuffleUpINTEL;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Previous { get; set; }
        public IdRef Current { get; set; }
        public IdRef Delta { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Previous", Previous);
            yield return new ReferenceProperty("Current", Current);
            yield return new ReferenceProperty("Delta", Delta);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Previous = IdRef.Parse(reader, end - reader.Position);
            Current = IdRef.Parse(reader, end - reader.Position);
            Delta = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Previous} {Current} {Delta}";
        }
    }
}