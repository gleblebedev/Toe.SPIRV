using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpExtInst : InstructionWithId
    {
        public override Op OpCode => Op.OpExtInst;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Set { get; set; }
        public uint Instruction { get; set; }
        public IList<IdRef> Operands { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Set", Set);
            for (var i = 0; i < Operands.Count; ++i)
                yield return new ReferenceProperty("Operands" + i, Operands[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Set = IdRef.Parse(reader, end - reader.Position);
            Instruction = LiteralExtInstInteger.Parse(reader, end - reader.Position);
            Operands = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Set} {Instruction} {Operands}";
        }
    }
}