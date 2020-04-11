using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageQueryFormat : FunctionNode 
    {
        public ImageQueryFormat(OpImageQueryFormat op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
        }

        public Node Image { get; set; }
    }
}