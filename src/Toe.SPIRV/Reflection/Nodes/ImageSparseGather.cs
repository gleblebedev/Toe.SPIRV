using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSparseGather : FunctionNode 
    {
        public ImageSparseGather(OpImageSparseGather op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Component = treeBuilder.GetNode(op.Component);
        }

        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
        public Node Component { get; set; }
    }
}