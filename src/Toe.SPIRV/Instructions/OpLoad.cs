using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpLoad : InstructionWithId
    {
        public override Op OpCode => Op.OpLoad;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Pointer { get; set; }
        public MemoryAccess MemoryAccess { get; set; }

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
            MemoryAccess = MemoryAccess.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pointer} {MemoryAccess}";
        }
    }
}