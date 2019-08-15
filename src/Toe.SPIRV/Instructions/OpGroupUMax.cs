using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupUMax : InstructionWithId
    {
        public override Op OpCode => Op.OpGroupUMax;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public uint Execution { get; set; }
        public GroupOperation Operation { get; set; }
        public IdRef X { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("X", X);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Execution = IdScope.Parse(reader, end - reader.Position);
            Operation = GroupOperation.Parse(reader, end - reader.Position);
            X = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Execution} {Operation} {X}";
        }
    }
}