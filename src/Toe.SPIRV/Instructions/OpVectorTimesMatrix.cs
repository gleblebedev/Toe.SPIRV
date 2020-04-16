using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpVectorTimesMatrix: InstructionWithId
    {
        public OpVectorTimesMatrix()
        {
        }

        public override Op OpCode { get { return Op.OpVectorTimesMatrix; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Vector { get; set; }

        public Spv.IdRef Matrix { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Vector", Vector);
            yield return new ReferenceProperty("Matrix", Matrix);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Vector = Spv.IdRef.Parse(reader, end-reader.Position);
            Matrix = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Vector.GetWordCount();
            wordCount += Matrix.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Vector.Write(writer);
            Matrix.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Vector} {Matrix}";
        }
    }
}
