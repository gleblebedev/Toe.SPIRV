using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeInitializeINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeInitializeINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeInitializeINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcCoord { get; set; }

        public Spv.IdRef PartitionMask { get; set; }

        public Spv.IdRef SADAdjustment { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SrcCoord = Spv.IdRef.Parse(reader, end-reader.Position);
            PartitionMask = Spv.IdRef.Parse(reader, end-reader.Position);
            SADAdjustment = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SrcCoord.GetWordCount();
            wordCount += PartitionMask.GetWordCount();
            wordCount += SADAdjustment.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SrcCoord.Write(writer);
            PartitionMask.Write(writer);
            SADAdjustment.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcCoord} {PartitionMask} {SADAdjustment}";
        }
    }
}
