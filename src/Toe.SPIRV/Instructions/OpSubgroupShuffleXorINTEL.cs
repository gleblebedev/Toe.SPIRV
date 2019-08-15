using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupShuffleXorINTEL : InstructionWithId
    {
        public override Op OpCode => Op.OpSubgroupShuffleXorINTEL;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Data { get; set; }
        public IdRef Value { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Data", Data);
            yield return new ReferenceProperty("Value", Value);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Data = IdRef.Parse(reader, end - reader.Position);
            Value = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Data} {Value}";
        }
    }
}