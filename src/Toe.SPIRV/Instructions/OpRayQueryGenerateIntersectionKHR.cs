using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpRayQueryGenerateIntersectionKHR: Instruction
    {
        public OpRayQueryGenerateIntersectionKHR()
        {
        }

        public override Op OpCode { get { return Op.OpRayQueryGenerateIntersectionKHR; } }

        public Spv.IdRef RayQuery { get; set; }

        public Spv.IdRef HitT { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            RayQuery = Spv.IdRef.Parse(reader, end-reader.Position);
            HitT = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += RayQuery.GetWordCount();
            wordCount += HitT.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            RayQuery.Write(writer);
            HitT.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {RayQuery} {HitT}";
        }
    }
}
