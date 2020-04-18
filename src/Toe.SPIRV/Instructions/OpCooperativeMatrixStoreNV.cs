using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCooperativeMatrixStoreNV: Instruction
    {
        public OpCooperativeMatrixStoreNV()
        {
        }

        public override Op OpCode { get { return Op.OpCooperativeMatrixStoreNV; } }

        public Spv.IdRef Pointer { get; set; }

        public Spv.IdRef Object { get; set; }

        public Spv.IdRef Stride { get; set; }

        public Spv.IdRef ColumnMajor { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Object = Spv.IdRef.Parse(reader, end-reader.Position);
            Stride = Spv.IdRef.Parse(reader, end-reader.Position);
            ColumnMajor = Spv.IdRef.Parse(reader, end-reader.Position);
            MemoryAccess = Spv.MemoryAccess.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Pointer.GetWordCount();
            wordCount += Object.GetWordCount();
            wordCount += Stride.GetWordCount();
            wordCount += ColumnMajor.GetWordCount();
            wordCount += MemoryAccess?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Pointer.Write(writer);
            Object.Write(writer);
            Stride.Write(writer);
            ColumnMajor.Write(writer);
            if (MemoryAccess != null) MemoryAccess.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Object} {Stride} {ColumnMajor} {MemoryAccess}";
        }
    }
}
