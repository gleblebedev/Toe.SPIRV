using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageDrefGather : FunctionNode 
    {
        public ImageDrefGather(OpImageDrefGather op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            D_ref = treeBuilder.GetNode(op.D_ref);
            Operands = treeBuilder.GetNodes(op.Operands);
        }

        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
        public Node D_ref { get; set; }
        public IList<Node> Operands { get; set; }
    }
}