using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpLoopMerge : Instruction
    {
        public override Op OpCode => Op.OpLoopMerge;

        public IdRef MergeBlock { get; set; }
        public IdRef ContinueTarget { get; set; }
        public LoopControl LoopControl { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("MergeBlock", MergeBlock);
            yield return new ReferenceProperty("ContinueTarget", ContinueTarget);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            MergeBlock = IdRef.Parse(reader, end - reader.Position);
            ContinueTarget = IdRef.Parse(reader, end - reader.Position);
            LoopControl = LoopControl.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {MergeBlock} {ContinueTarget} {LoopControl}";
        }
    }
}