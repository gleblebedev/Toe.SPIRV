using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpCompositeInsert : InstructionWithId
    {
        public override Op OpCode => Op.OpCompositeInsert;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Object { get; set; }
        public IdRef Composite { get; set; }
        public IList<uint> Indexes { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Object", Object);
            yield return new ReferenceProperty("Composite", Composite);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Object = IdRef.Parse(reader, end - reader.Position);
            Composite = IdRef.Parse(reader, end - reader.Position);
            Indexes = LiteralInteger.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Object} {Composite} {Indexes}";
        }
    }
}