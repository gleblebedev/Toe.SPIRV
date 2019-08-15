using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpVectorTimesMatrix : InstructionWithId
    {
        public override Op OpCode => Op.OpVectorTimesMatrix;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Vector { get; set; }
        public IdRef Matrix { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Vector", Vector);
            yield return new ReferenceProperty("Matrix", Matrix);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Vector = IdRef.Parse(reader, end - reader.Position);
            Matrix = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Vector} {Matrix}";
        }
    }
}