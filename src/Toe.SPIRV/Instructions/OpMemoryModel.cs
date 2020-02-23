using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpMemoryModel: Instruction
    {
        public OpMemoryModel()
        {
        }

        public override Op OpCode { get { return Op.OpMemoryModel; } }

        public Spv.AddressingModel AddressingModel { get; set; }
        public Spv.MemoryModel MemoryModel { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            AddressingModel = Spv.AddressingModel.Parse(reader, end-reader.Position);
            MemoryModel = Spv.MemoryModel.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += AddressingModel.GetWordCount();
            wordCount += MemoryModel.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            AddressingModel.Write(writer);
            MemoryModel.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {AddressingModel} {MemoryModel}";
        }
    }
}
