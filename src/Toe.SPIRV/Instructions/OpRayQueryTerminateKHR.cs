using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpRayQueryTerminateKHR: Instruction
    {
        public OpRayQueryTerminateKHR()
        {
        }

        public override Op OpCode { get { return Op.OpRayQueryTerminateKHR; } }

        public Spv.IdRef RayQuery { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("RayQuery", RayQuery);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            RayQuery = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += RayQuery.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            RayQuery.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {RayQuery}";
        }
    }
}
