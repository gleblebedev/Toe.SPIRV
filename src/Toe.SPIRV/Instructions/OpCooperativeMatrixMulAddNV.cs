using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCooperativeMatrixMulAddNV: InstructionWithId
    {
        public OpCooperativeMatrixMulAddNV()
        {
        }

        public override Op OpCode { get { return Op.OpCooperativeMatrixMulAddNV; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef A { get; set; }

        public Spv.IdRef B { get; set; }

        public Spv.IdRef C { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            A = Spv.IdRef.Parse(reader, end-reader.Position);
            B = Spv.IdRef.Parse(reader, end-reader.Position);
            C = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += A.GetWordCount();
            wordCount += B.GetWordCount();
            wordCount += C.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            A.Write(writer);
            B.Write(writer);
            C.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {A} {B} {C}";
        }
    }
}
