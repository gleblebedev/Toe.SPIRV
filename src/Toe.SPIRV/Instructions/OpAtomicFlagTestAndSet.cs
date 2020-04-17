using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpAtomicFlagTestAndSet: InstructionWithId
    {
        public OpAtomicFlagTestAndSet()
        {
        }

        public override Op OpCode { get { return Op.OpAtomicFlagTestAndSet; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Pointer { get; set; }

        public uint Memory { get; set; }

        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Memory = Spv.IdScope.Parse(reader, end-reader.Position);
            Semantics = Spv.IdMemorySemantics.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Pointer.GetWordCount();
            wordCount += Memory.GetWordCount();
            wordCount += Semantics.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Pointer.Write(writer);
            Memory.Write(writer);
            Semantics.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pointer} {Memory} {Semantics}";
        }
    }
}
