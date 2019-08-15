using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpULessThanEqual : InstructionWithId
    {
        public override Op OpCode => Op.OpULessThanEqual;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Operand1 { get; set; }
        public IdRef Operand2 { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Operand1", Operand1);
            yield return new ReferenceProperty("Operand2", Operand2);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Operand1 = IdRef.Parse(reader, end - reader.Position);
            Operand2 = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Operand1} {Operand2}";
        }
    }
}