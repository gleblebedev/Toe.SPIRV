using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CaptureEventProfilingInfo : SequentialOperationNode 
    {
        public CaptureEventProfilingInfo(OpCaptureEventProfilingInfo op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
            ProfilingInfo = treeBuilder.GetNode(op.ProfilingInfo);
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Event { get; set; }
        public Node ProfilingInfo { get; set; }
        public Node Value { get; set; }
    }
}