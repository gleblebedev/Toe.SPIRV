using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EnqueueMarker : FunctionNode 
    {
        public EnqueueMarker(OpEnqueueMarker op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Queue = treeBuilder.GetNode(op.Queue);
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            WaitEvents = treeBuilder.GetNode(op.WaitEvents);
            RetEvent = treeBuilder.GetNode(op.RetEvent);
        }

        public Node Queue { get; set; }
        public Node NumEvents { get; set; }
        public Node WaitEvents { get; set; }
        public Node RetEvent { get; set; }
    }
}