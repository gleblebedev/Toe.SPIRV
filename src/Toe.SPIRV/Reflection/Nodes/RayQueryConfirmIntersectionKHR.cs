using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class RayQueryConfirmIntersectionKHR : ExecutableNode, INodeWithNext
    {
        public RayQueryConfirmIntersectionKHR()
        {
        }

        public override Op OpCode => Op.OpRayQueryConfirmIntersectionKHR;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node RayQuery { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(RayQuery), RayQuery);
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
            SetUp((OpRayQueryConfirmIntersectionKHR)op, treeBuilder);
        }

        public void SetUp(OpRayQueryConfirmIntersectionKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            RayQuery = treeBuilder.GetNode(op.RayQuery);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}