using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSparseSampleProjImplicitLod : FunctionNode 
    {
        public ImageSparseSampleProjImplicitLod(OpImageSparseSampleProjImplicitLod op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
        }

        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
    }
}