using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSpecConstantTrue : InstructionWithId
    {
        public override Op OpCode => Op.OpSpecConstantTrue;

        public IdRef<TypeInstruction> IdResultType { get; set; }

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
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} ";
        }
    }
}