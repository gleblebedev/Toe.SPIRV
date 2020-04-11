using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageQueryLevels : FunctionNode 
    {
        public ImageQueryLevels(OpImageQueryLevels op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
        }

        public Node Image { get; set; }
    }
}