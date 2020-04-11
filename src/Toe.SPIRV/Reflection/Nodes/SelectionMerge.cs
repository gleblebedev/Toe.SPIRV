using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SelectionMerge : SequentialOperationNode 
    {
        public SelectionMerge(OpSelectionMerge op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

        public Node MergeBlock { get; set; }

        public override void FixForwardReferences(Instruction instruction, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.FixForwardReferences(instruction, treeBuilder);
            MergeBlock = treeBuilder.GetNode(((OpSelectionMerge)instruction).MergeBlock);
        }
    }
}