using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpRayQueryInitializeKHR: Instruction
    {
        public OpRayQueryInitializeKHR()
        {
        }

        public override Op OpCode { get { return Op.OpRayQueryInitializeKHR; } }

        public Spv.IdRef RayQuery { get; set; }

        public Spv.IdRef Accel { get; set; }

        public Spv.IdRef RayFlags { get; set; }

        public Spv.IdRef CullMask { get; set; }

        public Spv.IdRef RayOrigin { get; set; }

        public Spv.IdRef RayTMin { get; set; }

        public Spv.IdRef RayDirection { get; set; }

        public Spv.IdRef RayTMax { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("RayQuery", RayQuery);
            yield return new ReferenceProperty("Accel", Accel);
            yield return new ReferenceProperty("RayFlags", RayFlags);
            yield return new ReferenceProperty("CullMask", CullMask);
            yield return new ReferenceProperty("RayOrigin", RayOrigin);
            yield return new ReferenceProperty("RayTMin", RayTMin);
            yield return new ReferenceProperty("RayDirection", RayDirection);
            yield return new ReferenceProperty("RayTMax", RayTMax);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            RayQuery = Spv.IdRef.Parse(reader, end-reader.Position);
            Accel = Spv.IdRef.Parse(reader, end-reader.Position);
            RayFlags = Spv.IdRef.Parse(reader, end-reader.Position);
            CullMask = Spv.IdRef.Parse(reader, end-reader.Position);
            RayOrigin = Spv.IdRef.Parse(reader, end-reader.Position);
            RayTMin = Spv.IdRef.Parse(reader, end-reader.Position);
            RayDirection = Spv.IdRef.Parse(reader, end-reader.Position);
            RayTMax = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += RayQuery.GetWordCount();
            wordCount += Accel.GetWordCount();
            wordCount += RayFlags.GetWordCount();
            wordCount += CullMask.GetWordCount();
            wordCount += RayOrigin.GetWordCount();
            wordCount += RayTMin.GetWordCount();
            wordCount += RayDirection.GetWordCount();
            wordCount += RayTMax.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            RayQuery.Write(writer);
            Accel.Write(writer);
            RayFlags.Write(writer);
            CullMask.Write(writer);
            RayOrigin.Write(writer);
            RayTMin.Write(writer);
            RayDirection.Write(writer);
            RayTMax.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {RayQuery} {Accel} {RayFlags} {CullMask} {RayOrigin} {RayTMin} {RayDirection} {RayTMax}";
        }
    }
}
