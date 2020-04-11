using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupWaitEvents : SequentialOperationNode 
    {
        public GroupWaitEvents(OpGroupWaitEvents op, SpirvInstructionTreeBuilder treeBuilder)
        {
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            EventsList = treeBuilder.GetNode(op.EventsList);
        }

        public Node NumEvents { get; set; }
        public Node EventsList { get; set; }
    }
}