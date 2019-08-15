using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupShuffleINTEL : InstructionWithId
    {
        public override Op OpCode => Op.OpSubgroupShuffleINTEL;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Data { get; set; }
        public IdRef InvocationId { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Data", Data);
            yield return new ReferenceProperty("InvocationId", InvocationId);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Data = IdRef.Parse(reader, end - reader.Position);
            InvocationId = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Data} {InvocationId}";
        }
    }
}