using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LoopMerge : SequentialOperationNode 
    {
        public LoopMerge(OpLoopMerge op, SpirvInstructionTreeBuilder treeBuilder)
        {
            MergeBlock = treeBuilder.GetNode(op.MergeBlock);
            ContinueTarget = treeBuilder.GetNode(op.ContinueTarget);
        }

        public Node MergeBlock { get; set; }
        public Node ContinueTarget { get; set; }
    }
}