using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupWaitEvents : ExecutableNode 
    {
        public GroupWaitEvents()
        {
        }

        public Node NumEvents { get; set; }
        public Node EventsList { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(NumEvents), NumEvents);
                yield return CreateInputPin(nameof(EventsList), EventsList);
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
            SetUp((OpGroupWaitEvents)op, treeBuilder);
        }

        public void SetUp(OpGroupWaitEvents op, SpirvInstructionTreeBuilder treeBuilder)
        {
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            EventsList = treeBuilder.GetNode(op.EventsList);
        }
    }
}