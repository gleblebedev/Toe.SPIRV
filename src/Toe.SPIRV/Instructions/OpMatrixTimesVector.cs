using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMatrixTimesVector : InstructionWithId
    {
        public override Op OpCode => Op.OpMatrixTimesVector;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Matrix { get; set; }
        public IdRef Vector { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Matrix", Matrix);
            yield return new ReferenceProperty("Vector", Vector);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Matrix = IdRef.Parse(reader, end - reader.Position);
            Vector = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Matrix} {Vector}";
        }
    }
}