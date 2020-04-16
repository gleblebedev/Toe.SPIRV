using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpUnordered: InstructionWithId
    {
        public OpUnordered()
        {
        }

        public override Op OpCode { get { return Op.OpUnordered; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef x { get; set; }

        public Spv.IdRef y { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("x", x);
            yield return new ReferenceProperty("y", y);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            x = Spv.IdRef.Parse(reader, end-reader.Position);
            y = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += x.GetWordCount();
            wordCount += y.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            x.Write(writer);
            y.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {x} {y}";
        }
    }
}
