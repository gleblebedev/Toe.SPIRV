using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeVmeImageINTEL: TypeInstruction
    {
        public OpTypeVmeImageINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpTypeVmeImageINTEL; } }

        public Spv.IdRef ImageType { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ImageType = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += ImageType.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            ImageType.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ImageType}";
        }
    }
}
