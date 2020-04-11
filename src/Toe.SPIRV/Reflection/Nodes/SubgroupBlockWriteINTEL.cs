using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupBlockWriteINTEL : SequentialOperationNode 
    {
        public SubgroupBlockWriteINTEL(OpSubgroupBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Ptr = treeBuilder.GetNode(op.Ptr);
            Data = treeBuilder.GetNode(op.Data);
        }

        public Node Ptr { get; set; }
        public Node Data { get; set; }
    }
}