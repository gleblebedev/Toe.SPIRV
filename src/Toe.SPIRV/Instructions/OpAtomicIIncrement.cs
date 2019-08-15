using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpAtomicIIncrement : InstructionWithId
    {
        public override Op OpCode => Op.OpAtomicIIncrement;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Pointer { get; set; }
        public uint Scope { get; set; }
        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pointer", Pointer);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Pointer = IdRef.Parse(reader, end - reader.Position);
            Scope = IdScope.Parse(reader, end - reader.Position);
            Semantics = IdMemorySemantics.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pointer} {Scope} {Semantics}";
        }
    }
}