using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL: InstructionWithId
    {
        public OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef ChromaModeBasePenalty { get; set; }

        public Spv.IdRef Payload { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ChromaModeBasePenalty = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += ChromaModeBasePenalty.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            ChromaModeBasePenalty.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {ChromaModeBasePenalty} {Payload}";
        }
    }
}
