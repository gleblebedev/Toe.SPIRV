using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL: InstructionWithId
    {
        public OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef PackedSadCoefficients { get; set; }

        public Spv.IdRef Payload { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            PackedSadCoefficients = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += PackedSadCoefficients.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            PackedSadCoefficients.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {PackedSadCoefficients} {Payload}";
        }
    }
}
