using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeVector: TypeInstruction
    {
        public OpTypeVector()
        {
        }

        public override Op OpCode { get { return Op.OpTypeVector; } }

        public Spv.IdRef ComponentType { get; set; }

        public uint ComponentCount { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ComponentType = Spv.IdRef.Parse(reader, end-reader.Position);
            ComponentCount = Spv.LiteralInteger.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += ComponentType.GetWordCount();
            wordCount += ComponentCount.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            ComponentType.Write(writer);
            ComponentCount.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ComponentType} {ComponentCount}";
        }
    }
}
