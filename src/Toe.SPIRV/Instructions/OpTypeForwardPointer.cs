using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpTypeForwardPointer : Instruction
    {
        public override Op OpCode => Op.OpTypeForwardPointer;

        public IdRef PointerType { get; set; }
        public StorageClass StorageClass { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("PointerType", PointerType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            PointerType = IdRef.Parse(reader, end - reader.Position);
            StorageClass = StorageClass.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {PointerType} {StorageClass}";
        }
    }
}