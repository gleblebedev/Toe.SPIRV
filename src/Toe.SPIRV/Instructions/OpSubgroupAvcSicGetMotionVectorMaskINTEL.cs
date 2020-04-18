using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcSicGetMotionVectorMaskINTEL: InstructionWithId
    {
        public OpSubgroupAvcSicGetMotionVectorMaskINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcSicGetMotionVectorMaskINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SkipBlockPartitionType { get; set; }

        public Spv.IdRef Direction { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SkipBlockPartitionType = Spv.IdRef.Parse(reader, end-reader.Position);
            Direction = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SkipBlockPartitionType.GetWordCount();
            wordCount += Direction.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SkipBlockPartitionType.Write(writer);
            Direction.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SkipBlockPartitionType} {Direction}";
        }
    }
}
