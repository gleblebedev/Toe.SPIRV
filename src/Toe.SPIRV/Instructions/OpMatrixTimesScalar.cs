using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpMatrixTimesScalar: InstructionWithId
    {
        public OpMatrixTimesScalar()
        {
        }

        public override Op OpCode { get { return Op.OpMatrixTimesScalar; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Matrix { get; set; }

        public Spv.IdRef Scalar { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Matrix = Spv.IdRef.Parse(reader, end-reader.Position);
            Scalar = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Matrix.GetWordCount();
            wordCount += Scalar.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Matrix.Write(writer);
            Scalar.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Matrix} {Scalar}";
        }
    }
}
