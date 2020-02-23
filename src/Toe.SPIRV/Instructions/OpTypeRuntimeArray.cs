using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeRuntimeArray: TypeInstruction
    {
        public OpTypeRuntimeArray()
        {
        }

        public override Op OpCode { get { return Op.OpTypeRuntimeArray; } }

        public Spv.IdRef ElementType { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ElementType", ElementType);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ElementType = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += ElementType.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            ElementType.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ElementType}";
        }
    }
}
