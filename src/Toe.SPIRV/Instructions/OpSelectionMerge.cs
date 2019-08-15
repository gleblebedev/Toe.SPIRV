using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSelectionMerge : Instruction
    {
        public override Op OpCode => Op.OpSelectionMerge;

        public IdRef MergeBlock { get; set; }
        public SelectionControl SelectionControl { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("MergeBlock", MergeBlock);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            MergeBlock = IdRef.Parse(reader, end - reader.Position);
            SelectionControl = SelectionControl.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {MergeBlock} {SelectionControl}";
        }
    }
}