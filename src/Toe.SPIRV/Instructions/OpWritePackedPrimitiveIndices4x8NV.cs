using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpWritePackedPrimitiveIndices4x8NV: Instruction
    {
        public OpWritePackedPrimitiveIndices4x8NV()
        {
        }

        public override Op OpCode { get { return Op.OpWritePackedPrimitiveIndices4x8NV; } }

        public Spv.IdRef IndexOffset { get; set; }

        public Spv.IdRef PackedIndices { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IndexOffset = Spv.IdRef.Parse(reader, end-reader.Position);
            PackedIndices = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IndexOffset.GetWordCount();
            wordCount += PackedIndices.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IndexOffset.Write(writer);
            PackedIndices.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {IndexOffset} {PackedIndices}";
        }
    }
}
