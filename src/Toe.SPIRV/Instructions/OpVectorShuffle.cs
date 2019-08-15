using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpVectorShuffle : InstructionWithId
    {
        public override Op OpCode => Op.OpVectorShuffle;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Vector1 { get; set; }
        public IdRef Vector2 { get; set; }
        public IList<uint> Components { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Vector1", Vector1);
            yield return new ReferenceProperty("Vector2", Vector2);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Vector1 = IdRef.Parse(reader, end - reader.Position);
            Vector2 = IdRef.Parse(reader, end - reader.Position);
            Components = LiteralInteger.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Vector1} {Vector2} {Components}";
        }
    }
}