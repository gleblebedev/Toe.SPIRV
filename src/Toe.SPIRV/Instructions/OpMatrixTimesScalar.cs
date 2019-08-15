using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMatrixTimesScalar : InstructionWithId
    {
        public override Op OpCode => Op.OpMatrixTimesScalar;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Matrix { get; set; }
        public IdRef Scalar { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Matrix", Matrix);
            yield return new ReferenceProperty("Scalar", Scalar);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Matrix = IdRef.Parse(reader, end - reader.Position);
            Scalar = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Matrix} {Scalar}";
        }
    }
}