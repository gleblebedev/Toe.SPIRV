using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageWrite : SequentialOperationNode 
    {
        public ImageWrite(OpImageWrite op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Texel = treeBuilder.GetNode(op.Texel);
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Texel { get; set; }
    }
}