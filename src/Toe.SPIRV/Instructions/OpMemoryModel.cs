using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMemoryModel : Instruction
    {
        public override Op OpCode => Op.OpMemoryModel;

        public AddressingModel AddressingModel { get; set; }
        public MemoryModel MemoryModel { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            AddressingModel = AddressingModel.Parse(reader, end - reader.Position);
            MemoryModel = MemoryModel.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {AddressingModel} {MemoryModel}";
        }
    }
}