using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SetUserEventStatus : ExecutableNode, INodeWithNext
    {
        public SetUserEventStatus()
        {
        }

        public override Op OpCode => Op.OpSetUserEventStatus;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
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

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> EnterPins
        {
            get
            {
                yield return new NodePin(this, "", null);
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield return CreateExitPin("", GetNext());
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
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}