using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReleaseEvent : SequentialOperationNode 
    {
        public ReleaseEvent(OpReleaseEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
        }

        public Node Event { get; set; }
    }
}