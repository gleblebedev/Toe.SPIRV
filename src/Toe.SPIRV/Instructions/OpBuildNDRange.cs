using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpBuildNDRange: InstructionWithId
    {
        public OpBuildNDRange()
        {
        }

        public override Op OpCode { get { return Op.OpBuildNDRange; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef GlobalWorkSize { get; set; }

        public Spv.IdRef LocalWorkSize { get; set; }

        public Spv.IdRef GlobalWorkOffset { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            GlobalWorkSize = Spv.IdRef.Parse(reader, end-reader.Position);
            LocalWorkSize = Spv.IdRef.Parse(reader, end-reader.Position);
            GlobalWorkOffset = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += GlobalWorkSize.GetWordCount();
            wordCount += LocalWorkSize.GetWordCount();
            wordCount += GlobalWorkOffset.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            GlobalWorkSize.Write(writer);
            LocalWorkSize.Write(writer);
            GlobalWorkOffset.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {GlobalWorkSize} {LocalWorkSize} {GlobalWorkOffset}";
        }
    }
}
