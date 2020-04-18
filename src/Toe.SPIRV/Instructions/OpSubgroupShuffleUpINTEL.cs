using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupShuffleUpINTEL: InstructionWithId
    {
        public OpSubgroupShuffleUpINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupShuffleUpINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Previous { get; set; }

        public Spv.IdRef Current { get; set; }

        public Spv.IdRef Delta { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Previous = Spv.IdRef.Parse(reader, end-reader.Position);
            Current = Spv.IdRef.Parse(reader, end-reader.Position);
            Delta = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Previous.GetWordCount();
            wordCount += Current.GetWordCount();
            wordCount += Delta.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Previous.Write(writer);
            Current.Write(writer);
            Delta.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Previous} {Current} {Delta}";
        }
    }
}
