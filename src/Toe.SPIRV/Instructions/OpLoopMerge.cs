using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpLoopMerge: Instruction
    {
        public OpLoopMerge()
        {
        }

        public override Op OpCode { get { return Op.OpLoopMerge; } }

        public Spv.IdRef MergeBlock { get; set; }

        public Spv.IdRef ContinueTarget { get; set; }

        public Spv.LoopControl LoopControl { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            MergeBlock = Spv.IdRef.Parse(reader, end-reader.Position);
            ContinueTarget = Spv.IdRef.Parse(reader, end-reader.Position);
            LoopControl = Spv.LoopControl.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += MergeBlock.GetWordCount();
            wordCount += ContinueTarget.GetWordCount();
            wordCount += LoopControl.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            MergeBlock.Write(writer);
            ContinueTarget.Write(writer);
            LoopControl.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {MergeBlock} {ContinueTarget} {LoopControl}";
        }
    }
}
