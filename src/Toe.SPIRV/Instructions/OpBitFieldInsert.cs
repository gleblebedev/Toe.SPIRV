using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpBitFieldInsert: InstructionWithId
    {
        public OpBitFieldInsert()
        {
        }

        public override Op OpCode { get { return Op.OpBitFieldInsert; } }

        public Spv.IdRef<TypeInstruction> IdResultType { get; set; }
        public Spv.IdRef Base { get; set; }
        public Spv.IdRef Insert { get; set; }
        public Spv.IdRef Offset { get; set; }
        public Spv.IdRef Count { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Base", Base);
            yield return new ReferenceProperty("Insert", Insert);
            yield return new ReferenceProperty("Offset", Offset);
            yield return new ReferenceProperty("Count", Count);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Base = Spv.IdRef.Parse(reader, end-reader.Position);
            Insert = Spv.IdRef.Parse(reader, end-reader.Position);
            Offset = Spv.IdRef.Parse(reader, end-reader.Position);
            Count = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Base.GetWordCount();
            wordCount += Insert.GetWordCount();
            wordCount += Offset.GetWordCount();
            wordCount += Count.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Base.Write(writer);
            Insert.Write(writer);
            Offset.Write(writer);
            Count.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Base} {Insert} {Offset} {Count}";
        }
    }
}
