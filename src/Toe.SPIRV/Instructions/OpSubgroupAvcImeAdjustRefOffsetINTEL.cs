using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeAdjustRefOffsetINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeAdjustRefOffsetINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeAdjustRefOffsetINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef RefOffset { get; set; }

        public Spv.IdRef SrcCoord { get; set; }

        public Spv.IdRef RefWindowSize { get; set; }

        public Spv.IdRef ImageSize { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            RefOffset = Spv.IdRef.Parse(reader, end-reader.Position);
            SrcCoord = Spv.IdRef.Parse(reader, end-reader.Position);
            RefWindowSize = Spv.IdRef.Parse(reader, end-reader.Position);
            ImageSize = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += RefOffset.GetWordCount();
            wordCount += SrcCoord.GetWordCount();
            wordCount += RefWindowSize.GetWordCount();
            wordCount += ImageSize.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            RefOffset.Write(writer);
            SrcCoord.Write(writer);
            RefWindowSize.Write(writer);
            ImageSize.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {RefOffset} {SrcCoord} {RefWindowSize} {ImageSize}";
        }
    }
}
