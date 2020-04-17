using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupWaitEvents : ExecutableNode, INodeWithNext
    {
        public GroupWaitEvents()
        {
        }

        public override Op OpCode => Op.OpGroupWaitEvents;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public uint Execution { get; set; }
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
            SetUp((OpGroupWaitEvents)op, treeBuilder);
        }

        public void SetUp(OpGroupWaitEvents op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Execution = op.Execution;
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            EventsList = treeBuilder.GetNode(op.EventsList);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}