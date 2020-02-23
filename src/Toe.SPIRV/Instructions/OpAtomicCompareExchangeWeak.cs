using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpAtomicCompareExchangeWeak: InstructionWithId
    {
        public OpAtomicCompareExchangeWeak()
        {
        }

        public override Op OpCode { get { return Op.OpAtomicCompareExchangeWeak; } }

        public Spv.IdRef<TypeInstruction> IdResultType { get; set; }
        public Spv.IdRef Pointer { get; set; }
        public uint Scope { get; set; }
        public uint Equal { get; set; }
        public uint Unequal { get; set; }
        public Spv.IdRef Value { get; set; }
        public Spv.IdRef Comparator { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
            yield return new ReferenceProperty("Value", Value);
            yield return new ReferenceProperty("Comparator", Comparator);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Scope = Spv.IdScope.Parse(reader, end-reader.Position);
            Equal = Spv.IdMemorySemantics.Parse(reader, end-reader.Position);
            Unequal = Spv.IdMemorySemantics.Parse(reader, end-reader.Position);
            Value = Spv.IdRef.Parse(reader, end-reader.Position);
            Comparator = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Pointer.GetWordCount();
            wordCount += Scope.GetWordCount();
            wordCount += Equal.GetWordCount();
            wordCount += Unequal.GetWordCount();
            wordCount += Value.GetWordCount();
            wordCount += Comparator.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Pointer.Write(writer);
            Scope.Write(writer);
            Equal.Write(writer);
            Unequal.Write(writer);
            Value.Write(writer);
            Comparator.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pointer} {Scope} {Equal} {Unequal} {Value} {Comparator}";
        }
    }
}
