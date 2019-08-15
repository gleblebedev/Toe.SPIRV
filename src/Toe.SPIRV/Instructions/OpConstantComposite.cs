using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpConstantComposite : InstructionWithId
    {
        public override Op OpCode => Op.OpConstantComposite;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IList<IdRef> Constituents { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            for (var i = 0; i < Constituents.Count; ++i)
                yield return new ReferenceProperty("Constituents" + i, Constituents[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Constituents = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Constituents}";
        }
    }
}