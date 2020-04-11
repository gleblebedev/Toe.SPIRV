using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Image : FunctionNode 
    {
        public Image(OpImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
        }

        public Node SampledImage { get; set; }
    }
}