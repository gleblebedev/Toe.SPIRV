using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpAccessChain : InstructionWithId
    {
        public override Op OpCode => Op.OpAccessChain;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Base { get; set; }
        public IList<IdRef> Indexes { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Base", Base);
            for (var i = 0; i < Indexes.Count; ++i)
                yield return new ReferenceProperty("Indexes" + i, Indexes[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Base = IdRef.Parse(reader, end - reader.Position);
            Indexes = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Base} {Indexes}";
        }
    }
}