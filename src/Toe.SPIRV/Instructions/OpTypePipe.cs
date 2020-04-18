using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypePipe: TypeInstruction
    {
        public OpTypePipe()
        {
        }

        public override Op OpCode { get { return Op.OpTypePipe; } }

        public Spv.AccessQualifier Qualifier { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Qualifier = Spv.AccessQualifier.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += Qualifier.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            Qualifier.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {Qualifier}";
        }
    }
}
