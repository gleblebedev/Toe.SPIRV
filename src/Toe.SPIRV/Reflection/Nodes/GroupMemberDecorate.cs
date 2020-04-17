using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupMemberDecorate : ExecutableNode, INodeWithNext
    {
        public GroupMemberDecorate()
        {
        }

        public override Op OpCode => Op.OpGroupMemberDecorate;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node DecorationGroup { get; set; }
        public IList<Spv.PairIdRefLiteralInteger> Targets { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(DecorationGroup), DecorationGroup);
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
            SetUp((OpGroupMemberDecorate)op, treeBuilder);
        }

        public void SetUp(OpGroupMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
            Targets = op.Targets;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}