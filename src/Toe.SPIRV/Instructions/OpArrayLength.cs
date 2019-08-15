using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpArrayLength : InstructionWithId
    {
        public override Op OpCode => Op.OpArrayLength;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Structure { get; set; }
        public uint Arraymember { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Structure", Structure);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Structure = IdRef.Parse(reader, end - reader.Position);
            Arraymember = LiteralInteger.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Structure} {Arraymember}";
        }
    }
}