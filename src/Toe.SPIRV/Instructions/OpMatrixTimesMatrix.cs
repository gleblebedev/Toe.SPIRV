using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMatrixTimesMatrix : InstructionWithId
    {
        public override Op OpCode => Op.OpMatrixTimesMatrix;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef LeftMatrix { get; set; }
        public IdRef RightMatrix { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("LeftMatrix", LeftMatrix);
            yield return new ReferenceProperty("RightMatrix", RightMatrix);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            LeftMatrix = IdRef.Parse(reader, end - reader.Position);
            RightMatrix = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {LeftMatrix} {RightMatrix}";
        }
    }
}