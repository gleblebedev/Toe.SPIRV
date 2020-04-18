using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpVmeImageINTEL: InstructionWithId
    {
        public OpVmeImageINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpVmeImageINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef ImageType { get; set; }

        public Spv.IdRef Sampler { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ImageType = Spv.IdRef.Parse(reader, end-reader.Position);
            Sampler = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += ImageType.GetWordCount();
            wordCount += Sampler.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            ImageType.Write(writer);
            Sampler.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {ImageType} {Sampler}";
        }
    }
}
