using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageTexelPointer : FunctionNode 
    {
        public ImageTexelPointer(OpImageTexelPointer op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Sample = treeBuilder.GetNode(op.Sample);
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Sample { get; set; }
    }
}