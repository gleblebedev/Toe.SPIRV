using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpShiftRightArithmetic : InstructionWithId
    {
        public override Op OpCode => Op.OpShiftRightArithmetic;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Base { get; set; }
        public IdRef Shift { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Base", Base);
            yield return new ReferenceProperty("Shift", Shift);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Base = IdRef.Parse(reader, end - reader.Position);
            Shift = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Base} {Shift}";
        }
    }
}