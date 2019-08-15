using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSelect : InstructionWithId
    {
        public override Op OpCode => Op.OpSelect;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Condition { get; set; }
        public IdRef Object1 { get; set; }
        public IdRef Object2 { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Condition", Condition);
            yield return new ReferenceProperty("Object1", Object1);
            yield return new ReferenceProperty("Object2", Object2);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Condition = IdRef.Parse(reader, end - reader.Position);
            Object1 = IdRef.Parse(reader, end - reader.Position);
            Object2 = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Condition} {Object1} {Object2}";
        }
    }
}