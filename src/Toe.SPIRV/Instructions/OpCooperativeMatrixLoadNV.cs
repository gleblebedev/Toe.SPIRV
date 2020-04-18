using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCooperativeMatrixLoadNV: InstructionWithId
    {
        public OpCooperativeMatrixLoadNV()
        {
        }

        public override Op OpCode { get { return Op.OpCooperativeMatrixLoadNV; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Pointer { get; set; }

        public Spv.IdRef Stride { get; set; }

        public Spv.IdRef ColumnMajor { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Stride = Spv.IdRef.Parse(reader, end-reader.Position);
            ColumnMajor = Spv.IdRef.Parse(reader, end-reader.Position);
            MemoryAccess = Spv.MemoryAccess.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Pointer.GetWordCount();
            wordCount += Stride.GetWordCount();
            wordCount += ColumnMajor.GetWordCount();
            wordCount += MemoryAccess?.GetWordCount() ?? 0u;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Pointer.Write(writer);
            Stride.Write(writer);
            ColumnMajor.Write(writer);
            if (MemoryAccess != null) MemoryAccess.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pointer} {Stride} {ColumnMajor} {MemoryAccess}";
        }
    }
}
