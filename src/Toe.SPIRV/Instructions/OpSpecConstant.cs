using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSpecConstant : InstructionWithId
    {
        public override Op OpCode => Op.OpSpecConstant;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public LiteralContextDependentNumber Value { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Value = LiteralContextDependentNumber.ParseOptional(reader, end - reader.Position,
                IdResultType.Instruction);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Value}";
        }
    }
}