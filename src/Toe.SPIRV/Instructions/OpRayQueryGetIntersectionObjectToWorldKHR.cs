using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpRayQueryGetIntersectionObjectToWorldKHR: InstructionWithId
    {
        public OpRayQueryGetIntersectionObjectToWorldKHR()
        {
        }

        public override Op OpCode { get { return Op.OpRayQueryGetIntersectionObjectToWorldKHR; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef RayQuery { get; set; }

        public Spv.IdRef Intersection { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("RayQuery", RayQuery);
            yield return new ReferenceProperty("Intersection", Intersection);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            RayQuery = Spv.IdRef.Parse(reader, end-reader.Position);
            Intersection = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += RayQuery.GetWordCount();
            wordCount += Intersection.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            RayQuery.Write(writer);
            Intersection.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {RayQuery} {Intersection}";
        }
    }
}