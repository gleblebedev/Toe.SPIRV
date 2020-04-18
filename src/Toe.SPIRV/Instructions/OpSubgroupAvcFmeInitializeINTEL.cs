using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcFmeInitializeINTEL: InstructionWithId
    {
        public OpSubgroupAvcFmeInitializeINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcFmeInitializeINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcCoord { get; set; }

        public Spv.IdRef MotionVectors { get; set; }

        public Spv.IdRef MajorShapes { get; set; }

        public Spv.IdRef MinorShapes { get; set; }

        public Spv.IdRef Direction { get; set; }

        public Spv.IdRef PixelResolution { get; set; }

        public Spv.IdRef SadAdjustment { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SrcCoord = Spv.IdRef.Parse(reader, end-reader.Position);
            MotionVectors = Spv.IdRef.Parse(reader, end-reader.Position);
            MajorShapes = Spv.IdRef.Parse(reader, end-reader.Position);
            MinorShapes = Spv.IdRef.Parse(reader, end-reader.Position);
            Direction = Spv.IdRef.Parse(reader, end-reader.Position);
            PixelResolution = Spv.IdRef.Parse(reader, end-reader.Position);
            SadAdjustment = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SrcCoord.GetWordCount();
            wordCount += MotionVectors.GetWordCount();
            wordCount += MajorShapes.GetWordCount();
            wordCount += MinorShapes.GetWordCount();
            wordCount += Direction.GetWordCount();
            wordCount += PixelResolution.GetWordCount();
            wordCount += SadAdjustment.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SrcCoord.Write(writer);
            MotionVectors.Write(writer);
            MajorShapes.Write(writer);
            MinorShapes.Write(writer);
            Direction.Write(writer);
            PixelResolution.Write(writer);
            SadAdjustment.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcCoord} {MotionVectors} {MajorShapes} {MinorShapes} {Direction} {PixelResolution} {SadAdjustment}";
        }
    }
}
