using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeFloat: TypeInstruction
    {
        public OpTypeFloat()
        {
        }

        public override Op OpCode { get { return Op.OpTypeFloat; } }

        public uint Width { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Width = Spv.LiteralInteger.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += Width.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            Width.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {Width}";
        }
    }
}
