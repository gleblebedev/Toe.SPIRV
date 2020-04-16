using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeArray: TypeInstruction
    {
        public OpTypeArray()
        {
        }

        public override Op OpCode { get { return Op.OpTypeArray; } }

        public Spv.IdRef ElementType { get; set; }

        public Spv.IdRef Length { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ElementType", ElementType);
            yield return new ReferenceProperty("Length", Length);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ElementType = Spv.IdRef.Parse(reader, end-reader.Position);
            Length = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += ElementType.GetWordCount();
            wordCount += Length.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            ElementType.Write(writer);
            Length.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ElementType} {Length}";
        }
    }
}
