using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SetUserEventStatus : SequentialOperationNode 
    {
        public SetUserEventStatus(OpSetUserEventStatus op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
            Status = treeBuilder.GetNode(op.Status);
        }

        public Node Event { get; set; }
        public Node Status { get; set; }
    }
}