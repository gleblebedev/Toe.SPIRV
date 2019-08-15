using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpVariable : InstructionWithId
    {
        public override Op OpCode => Op.OpVariable;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public StorageClass StorageClass { get; set; }
        public IdRef Initializer { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Initializer", Initializer);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            StorageClass = StorageClass.Parse(reader, end - reader.Position);
            Initializer = IdRef.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {StorageClass} {Initializer}";
        }
    }
}