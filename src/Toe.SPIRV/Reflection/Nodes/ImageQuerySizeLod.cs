using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageQuerySizeLod : FunctionNode 
    {
        public ImageQuerySizeLod(OpImageQuerySizeLod op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            LevelofDetail = treeBuilder.GetNode(op.LevelofDetail);
        }

        public Node Image { get; set; }
        public Node LevelofDetail { get; set; }
    }
}