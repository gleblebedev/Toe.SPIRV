using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpMatrixTimesMatrix: InstructionWithId
    {
        public OpMatrixTimesMatrix()
        {
        }

        public override Op OpCode { get { return Op.OpMatrixTimesMatrix; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef LeftMatrix { get; set; }

        public Spv.IdRef RightMatrix { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            LeftMatrix = Spv.IdRef.Parse(reader, end-reader.Position);
            RightMatrix = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += LeftMatrix.GetWordCount();
            wordCount += RightMatrix.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            LeftMatrix.Write(writer);
            RightMatrix.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {LeftMatrix} {RightMatrix}";
        }
    }
}
