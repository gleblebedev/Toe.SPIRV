using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupReadInvocationKHR : InstructionWithId
    {
        public override Op OpCode => Op.OpSubgroupReadInvocationKHR;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Value { get; set; }
        public IdRef Index { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Value", Value);
            yield return new ReferenceProperty("Index", Index);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Value = IdRef.Parse(reader, end - reader.Position);
            Index = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Value} {Index}";
        }
    }
}