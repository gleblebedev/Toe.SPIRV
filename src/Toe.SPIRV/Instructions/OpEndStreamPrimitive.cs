using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpEndStreamPrimitive: Instruction
    {
        public OpEndStreamPrimitive()
        {
        }

        public override Op OpCode { get { return Op.OpEndStreamPrimitive; } }

        public Spv.IdRef Stream { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Stream", Stream);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Stream = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Stream.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Stream.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Stream}";
        }
    }
}
