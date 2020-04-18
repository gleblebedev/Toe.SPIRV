using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Payload { get; set; }

        public Spv.IdRef MajorShape { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
            MajorShape = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Payload.GetWordCount();
            wordCount += MajorShape.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Payload.Write(writer);
            MajorShape.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Payload} {MajorShape}";
        }
    }
}
