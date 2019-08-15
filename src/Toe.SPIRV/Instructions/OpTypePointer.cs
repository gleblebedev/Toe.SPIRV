using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpTypePointer : TypeInstruction
    {
        public override Op OpCode => Op.OpTypePointer;

        public StorageClass StorageClass { get; set; }
        public IdRef Type { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Type", Type);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            StorageClass = StorageClass.Parse(reader, end - reader.Position);
            Type = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {StorageClass} {Type}";
        }
    }
}