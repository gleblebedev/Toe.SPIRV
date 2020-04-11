using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageRead : FunctionNode 
    {
        public ImageRead(OpImageRead op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
    }
}