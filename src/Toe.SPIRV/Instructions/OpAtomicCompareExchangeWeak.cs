using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpAtomicCompareExchangeWeak : InstructionWithId
    {
        public override Op OpCode => Op.OpAtomicCompareExchangeWeak;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Pointer { get; set; }
        public uint Scope { get; set; }
        public uint Equal { get; set; }
        public uint Unequal { get; set; }
        public IdRef Value { get; set; }
        public IdRef Comparator { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
            yield return new ReferenceProperty("Value", Value);
            yield return new ReferenceProperty("Comparator", Comparator);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Pointer = IdRef.Parse(reader, end - reader.Position);
            Scope = IdScope.Parse(reader, end - reader.Position);
            Equal = IdMemorySemantics.Parse(reader, end - reader.Position);
            Unequal = IdMemorySemantics.Parse(reader, end - reader.Position);
            Value = IdRef.Parse(reader, end - reader.Position);
            Comparator = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pointer} {Scope} {Equal} {Unequal} {Value} {Comparator}";
        }
    }
}