using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupBroadcast : InstructionWithId
    {
        public override Op OpCode => Op.OpGroupBroadcast;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public uint Execution { get; set; }
        public IdRef Value { get; set; }
        public IdRef LocalId { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Value", Value);
            yield return new ReferenceProperty("LocalId", LocalId);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Execution = IdScope.Parse(reader, end - reader.Position);
            Value = IdRef.Parse(reader, end - reader.Position);
            LocalId = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Execution} {Value} {LocalId}";
        }
    }
}