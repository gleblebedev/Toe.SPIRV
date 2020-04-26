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
        
        /// <summary>
        /// Returns true if instruction has IdResult field.
        /// </summary>
        public override bool HasResultId => false;

        /// <summary>
        /// Returns true if instruction has IdResultType field.
        /// </summary>
        public override bool HasResultType => false;

        public Spv.IdRef Pointer { get; set; }

        public Spv.IdRef Object { get; set; }

        public Spv.IdRef Stride { get; set; }

        public Spv.IdRef ColumnMajor { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }

        /// <summary>
        /// Read complete instruction from the bytecode source.
        /// </summary>
        /// <param name="reader">Bytecode source.</param>
        /// <param name="end">Index of a next word right after this instruction.</param>
        public override void Parse(WordReader reader, uint end)
        {
            ParseOperands(reader, end);
            PostParse(reader, end);
        }

        /// <summary>
        /// Read instruction operands from the bytecode source.
        /// </summary>
        /// <param name="reader">Bytecode source.</param>
        /// <param name="end">Index of a next word right after this instruction.</param>
        public override void ParseOperands(WordReader reader, uint end)
        {
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            Object = Spv.IdRef.Parse(reader, end-reader.Position);
            Stride = Spv.IdRef.Parse(reader, end-reader.Position);
            ColumnMajor = Spv.IdRef.Parse(reader, end-reader.Position);
            MemoryAccess = Spv.MemoryAccess.ParseOptional(reader, end-reader.Position);
        }

        /// <summary>
        /// Process parsed instruction if required.
        /// </summary>
        /// <param name="reader">Bytecode source.</param>
        /// <param name="end">Index of a next word right after this instruction.</param>
        partial void PostParse(WordReader reader, uint end);

        /// <summary>
        /// Calculate number of words to fit complete instruction bytecode.
        /// </summary>
        /// <returns>Number of words in instruction bytecode.</returns>
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

        /// <summary>
        /// Write instruction into bytecode stream.
        /// </summary>
        /// <param name="writer">Bytecode writer.</param>
        public override void Write(WordWriter writer)
        {
            WriteOperands(writer);
            WriteExtras(writer);
        }

        /// <summary>
        /// Write instruction operands into bytecode stream.
        /// </summary>
        /// <param name="writer">Bytecode writer.</param>
        public override void WriteOperands(WordWriter writer)
        {
            Pointer.Write(writer);
            Object.Write(writer);
            Stride.Write(writer);
            ColumnMajor.Write(writer);
            if (MemoryAccess != null) MemoryAccess.Write(writer);
        }

        partial void WriteExtras(WordWriter writer);

        public override string ToString()
        {
            return $"{OpCode} {Pointer} {Object} {Stride} {ColumnMajor} {MemoryAccess}";
        }
    }
}
