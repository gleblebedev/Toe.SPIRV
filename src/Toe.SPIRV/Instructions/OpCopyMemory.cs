using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCopyMemory: Instruction
    {
        public OpCopyMemory()
        {
        }

        public override Op OpCode { get { return Op.OpCopyMemory; } }

        public Spv.IdRef Target { get; set; }

        public Spv.IdRef Source { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }

        public Spv.MemoryAccess MemoryAccess2 { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Target = Spv.IdRef.Parse(reader, end-reader.Position);
            Source = Spv.IdRef.Parse(reader, end-reader.Position);
            MemoryAccess = Spv.MemoryAccess.ParseOptional(reader, end-reader.Position);
            MemoryAccess2 = Spv.MemoryAccess.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Target.GetWordCount();
            wordCount += Source.GetWordCount();
            wordCount += MemoryAccess?.GetWordCount() ?? 0u;
            wordCount += MemoryAccess2?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Target.Write(writer);
            Source.Write(writer);
            if (MemoryAccess != null) MemoryAccess.Write(writer);
            if (MemoryAccess2 != null) MemoryAccess2.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Target} {Source} {MemoryAccess} {MemoryAccess2}";
        }
    }
}
