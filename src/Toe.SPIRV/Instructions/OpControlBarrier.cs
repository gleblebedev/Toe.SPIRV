using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpControlBarrier: Instruction
    {
        public OpControlBarrier()
        {
        }

        public override Op OpCode { get { return Op.OpControlBarrier; } }

        public uint Execution { get; set; }

        public uint Memory { get; set; }

        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Execution = Spv.IdScope.Parse(reader, end-reader.Position);
            Memory = Spv.IdScope.Parse(reader, end-reader.Position);
            Semantics = Spv.IdMemorySemantics.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Execution.GetWordCount();
            wordCount += Memory.GetWordCount();
            wordCount += Semantics.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Execution.Write(writer);
            Memory.Write(writer);
            Semantics.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Execution} {Memory} {Semantics}";
        }
    }
}
