using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcSicConfigureIpeLumaChromaINTEL: InstructionWithId
    {
        public OpSubgroupAvcSicConfigureIpeLumaChromaINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcSicConfigureIpeLumaChromaINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef LumaIntraPartitionMask { get; set; }

        public Spv.IdRef IntraNeighbourAvailabilty { get; set; }

        public Spv.IdRef LeftEdgeLumaPixels { get; set; }

        public Spv.IdRef UpperLeftCornerLumaPixel { get; set; }

        public Spv.IdRef UpperEdgeLumaPixels { get; set; }

        public Spv.IdRef UpperRightEdgeLumaPixels { get; set; }

        public Spv.IdRef LeftEdgeChromaPixels { get; set; }

        public Spv.IdRef UpperLeftCornerChromaPixel { get; set; }

        public Spv.IdRef UpperEdgeChromaPixels { get; set; }

        public Spv.IdRef SadAdjustment { get; set; }

        public Spv.IdRef Payload { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            LumaIntraPartitionMask = Spv.IdRef.Parse(reader, end-reader.Position);
            IntraNeighbourAvailabilty = Spv.IdRef.Parse(reader, end-reader.Position);
            LeftEdgeLumaPixels = Spv.IdRef.Parse(reader, end-reader.Position);
            UpperLeftCornerLumaPixel = Spv.IdRef.Parse(reader, end-reader.Position);
            UpperEdgeLumaPixels = Spv.IdRef.Parse(reader, end-reader.Position);
            UpperRightEdgeLumaPixels = Spv.IdRef.Parse(reader, end-reader.Position);
            LeftEdgeChromaPixels = Spv.IdRef.Parse(reader, end-reader.Position);
            UpperLeftCornerChromaPixel = Spv.IdRef.Parse(reader, end-reader.Position);
            UpperEdgeChromaPixels = Spv.IdRef.Parse(reader, end-reader.Position);
            SadAdjustment = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += LumaIntraPartitionMask.GetWordCount();
            wordCount += IntraNeighbourAvailabilty.GetWordCount();
            wordCount += LeftEdgeLumaPixels.GetWordCount();
            wordCount += UpperLeftCornerLumaPixel.GetWordCount();
            wordCount += UpperEdgeLumaPixels.GetWordCount();
            wordCount += UpperRightEdgeLumaPixels.GetWordCount();
            wordCount += LeftEdgeChromaPixels.GetWordCount();
            wordCount += UpperLeftCornerChromaPixel.GetWordCount();
            wordCount += UpperEdgeChromaPixels.GetWordCount();
            wordCount += SadAdjustment.GetWordCount();
            wordCount += Payload.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            LumaIntraPartitionMask.Write(writer);
            IntraNeighbourAvailabilty.Write(writer);
            LeftEdgeLumaPixels.Write(writer);
            UpperLeftCornerLumaPixel.Write(writer);
            UpperEdgeLumaPixels.Write(writer);
            UpperRightEdgeLumaPixels.Write(writer);
            LeftEdgeChromaPixels.Write(writer);
            UpperLeftCornerChromaPixel.Write(writer);
            UpperEdgeChromaPixels.Write(writer);
            SadAdjustment.Write(writer);
            Payload.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {LumaIntraPartitionMask} {IntraNeighbourAvailabilty} {LeftEdgeLumaPixels} {UpperLeftCornerLumaPixel} {UpperEdgeLumaPixels} {UpperRightEdgeLumaPixels} {LeftEdgeChromaPixels} {UpperLeftCornerChromaPixel} {UpperEdgeChromaPixels} {SadAdjustment} {Payload}";
        }
    }
}
