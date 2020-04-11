using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupImageBlockWriteINTEL : SequentialOperationNode 
    {
        public SubgroupImageBlockWriteINTEL(OpSubgroupImageBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Data = treeBuilder.GetNode(op.Data);
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Data { get; set; }
    }
}