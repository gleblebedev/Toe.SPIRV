using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpMemoryNamedBarrier: Instruction
    {
        public OpMemoryNamedBarrier()
        {
        }

        public override Op OpCode { get { return Op.OpMemoryNamedBarrier; } }

        public Spv.IdRef NamedBarrier { get; set; }

        public uint Memory { get; set; }

        public uint Semantics { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("NamedBarrier", NamedBarrier);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            NamedBarrier = Spv.IdRef.Parse(reader, end-reader.Position);
            Memory = Spv.IdScope.Parse(reader, end-reader.Position);
            Semantics = Spv.IdMemorySemantics.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += NamedBarrier.GetWordCount();
            wordCount += Memory.GetWordCount();
            wordCount += Semantics.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            NamedBarrier.Write(writer);
            Memory.Write(writer);
            Semantics.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {NamedBarrier} {Memory} {Semantics}";
        }
    }
}
