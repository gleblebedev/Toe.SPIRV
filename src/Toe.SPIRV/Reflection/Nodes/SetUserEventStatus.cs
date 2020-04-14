using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SetUserEventStatus : ExecutableNode 
    {
        public SetUserEventStatus()
        {
        }

        public Node Event { get; set; }
        public Node Status { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Event), Event);
                yield return CreateInputPin(nameof(Status), Status);
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
            SetUp((OpSetUserEventStatus)op, treeBuilder);
        }

        public void SetUp(OpSetUserEventStatus op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
            Status = treeBuilder.GetNode(op.Status);
        }
    }
}