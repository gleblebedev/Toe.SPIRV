using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL: InstructionWithId
    {
        public OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef PackedReferenceIds { get; set; }

        public Spv.IdRef PackedReferenceParameterFieldPolarities { get; set; }

        public Spv.IdRef Payload { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            PackedReferenceIds = Spv.IdRef.Parse(reader, end-reader.Position);
            PackedReferenceParameterFieldPolarities = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += PackedReferenceIds.GetWordCount();
            wordCount += PackedReferenceParameterFieldPolarities.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            PackedReferenceIds.Write(writer);
            PackedReferenceParameterFieldPolarities.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {PackedReferenceIds} {PackedReferenceParameterFieldPolarities} {Payload}";
        }
    }
}
