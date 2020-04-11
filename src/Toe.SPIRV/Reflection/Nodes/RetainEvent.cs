using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class RetainEvent : SequentialOperationNode 
    {
        public RetainEvent(OpRetainEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
        }

        public Node Event { get; set; }
    }
}