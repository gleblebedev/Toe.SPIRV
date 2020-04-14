using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EnqueueMarker : FunctionNode 
    {
        public EnqueueMarker()
        {
        }

        public Node Queue { get; set; }
        public Node NumEvents { get; set; }
        public Node WaitEvents { get; set; }
        public Node RetEvent { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Queue), Queue);
                yield return CreateInputPin(nameof(NumEvents), NumEvents);
                yield return CreateInputPin(nameof(WaitEvents), WaitEvents);
                yield return CreateInputPin(nameof(RetEvent), RetEvent);
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
            SetUp((OpEnqueueMarker)op, treeBuilder);
        }

        public void SetUp(OpEnqueueMarker op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Queue = treeBuilder.GetNode(op.Queue);
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            WaitEvents = treeBuilder.GetNode(op.WaitEvents);
            RetEvent = treeBuilder.GetNode(op.RetEvent);
        }
    }
}