using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CaptureEventProfilingInfo : ExecutableNode 
    {
        public CaptureEventProfilingInfo()
        {
        }

        public Node Event { get; set; }
        public Node ProfilingInfo { get; set; }
        public Node Value { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Event), Event);
                yield return CreateInputPin(nameof(ProfilingInfo), ProfilingInfo);
                yield return CreateInputPin(nameof(Value), Value);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpCaptureEventProfilingInfo)op, treeBuilder);
        }

        public void SetUp(OpCaptureEventProfilingInfo op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
            ProfilingInfo = treeBuilder.GetNode(op.ProfilingInfo);
            Value = treeBuilder.GetNode(op.Value);
        }
    }
}