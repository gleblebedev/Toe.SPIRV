using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpStore: Instruction
    {
        public OpStore()
        {
        }

        public override Op OpCode { get { return Op.OpStore; } }

        public Spv.IdRef Pointer { get; set; }

        public Spv.IdRef Object { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
            yield return new ReferenceProperty("Object", Object);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Object = Spv.IdRef.Parse(reader, end-reader.Position);
            MemoryAccess = Spv.MemoryAccess.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Pointer.GetWordCount();
            wordCount += Object.GetWordCount();
            wordCount += MemoryAccess?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Pointer.Write(writer);
            Object.Write(writer);
            if (MemoryAccess != null) MemoryAccess.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Object} {MemoryAccess}";
        }
    }
}
