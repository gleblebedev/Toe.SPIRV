using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSparseSampleProjDrefImplicitLod : FunctionNode 
    {
        public ImageSparseSampleProjDrefImplicitLod(OpImageSparseSampleProjDrefImplicitLod op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            D_ref = treeBuilder.GetNode(op.D_ref);
        }

        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
        public Node D_ref { get; set; }
    }
}