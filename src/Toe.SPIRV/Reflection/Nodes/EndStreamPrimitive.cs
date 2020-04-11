using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EndStreamPrimitive : SequentialOperationNode 
    {
        public EndStreamPrimitive(OpEndStreamPrimitive op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Stream = treeBuilder.GetNode(op.Stream);
        }

        public Node Stream { get; set; }
    }
}