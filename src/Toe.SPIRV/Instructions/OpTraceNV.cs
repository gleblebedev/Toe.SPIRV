using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTraceNV: Instruction
    {
        public OpTraceNV()
        {
        }

        public override Op OpCode { get { return Op.OpTraceNV; } }

        public Spv.IdRef Accel { get; set; }

        public Spv.IdRef RayFlags { get; set; }

        public Spv.IdRef CullMask { get; set; }

        public Spv.IdRef SBTOffset { get; set; }

        public Spv.IdRef SBTStride { get; set; }

        public Spv.IdRef MissIndex { get; set; }

        public Spv.IdRef RayOrigin { get; set; }

        public Spv.IdRef RayTmin { get; set; }

        public Spv.IdRef RayDirection { get; set; }

        public Spv.IdRef RayTmax { get; set; }

        public Spv.IdRef PayloadId { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Accel = Spv.IdRef.Parse(reader, end-reader.Position);
            RayFlags = Spv.IdRef.Parse(reader, end-reader.Position);
            CullMask = Spv.IdRef.Parse(reader, end-reader.Position);
            SBTOffset = Spv.IdRef.Parse(reader, end-reader.Position);
            SBTStride = Spv.IdRef.Parse(reader, end-reader.Position);
            MissIndex = Spv.IdRef.Parse(reader, end-reader.Position);
            RayOrigin = Spv.IdRef.Parse(reader, end-reader.Position);
            RayTmin = Spv.IdRef.Parse(reader, end-reader.Position);
            RayDirection = Spv.IdRef.Parse(reader, end-reader.Position);
            RayTmax = Spv.IdRef.Parse(reader, end-reader.Position);
            PayloadId = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Accel.GetWordCount();
            wordCount += RayFlags.GetWordCount();
            wordCount += CullMask.GetWordCount();
            wordCount += SBTOffset.GetWordCount();
            wordCount += SBTStride.GetWordCount();
            wordCount += MissIndex.GetWordCount();
            wordCount += RayOrigin.GetWordCount();
            wordCount += RayTmin.GetWordCount();
            wordCount += RayDirection.GetWordCount();
            wordCount += RayTmax.GetWordCount();
            wordCount += PayloadId.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Accel.Write(writer);
            RayFlags.Write(writer);
            CullMask.Write(writer);
            SBTOffset.Write(writer);
            SBTStride.Write(writer);
            MissIndex.Write(writer);
            RayOrigin.Write(writer);
            RayTmin.Write(writer);
            RayDirection.Write(writer);
            RayTmax.Write(writer);
            PayloadId.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Accel} {RayFlags} {CullMask} {SBTOffset} {SBTStride} {MissIndex} {RayOrigin} {RayTmin} {RayDirection} {RayTmax} {PayloadId}";
        }
    }
}
