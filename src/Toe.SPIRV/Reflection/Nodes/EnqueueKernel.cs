using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EnqueueKernel : FunctionNode 
    {
        public EnqueueKernel(OpEnqueueKernel op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Queue = treeBuilder.GetNode(op.Queue);
            Flags = treeBuilder.GetNode(op.Flags);
            NDRange = treeBuilder.GetNode(op.NDRange);
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            WaitEvents = treeBuilder.GetNode(op.WaitEvents);
            RetEvent = treeBuilder.GetNode(op.RetEvent);
            Invoke = treeBuilder.GetNode(op.Invoke);
            Param = treeBuilder.GetNode(op.Param);
            ParamSize = treeBuilder.GetNode(op.ParamSize);
            ParamAlign = treeBuilder.GetNode(op.ParamAlign);
            LocalSize = treeBuilder.GetNodes(op.LocalSize);
        }

        public Node Queue { get; set; }
        public Node Flags { get; set; }
        public Node NDRange { get; set; }
        public Node NumEvents { get; set; }
        public Node WaitEvents { get; set; }
        public Node RetEvent { get; set; }
        public Node Invoke { get; set; }
        public Node Param { get; set; }
        public Node ParamSize { get; set; }
        public Node ParamAlign { get; set; }
        public IList<Node> LocalSize { get; set; }
    }
}