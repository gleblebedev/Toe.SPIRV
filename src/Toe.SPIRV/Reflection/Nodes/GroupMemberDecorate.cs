using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupMemberDecorate : ExecutableNode 
    {
        public GroupMemberDecorate()
        {
        }

        public Node DecorationGroup { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(DecorationGroup), DecorationGroup);
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
            SetUp((OpGroupMemberDecorate)op, treeBuilder);
        }

        public void SetUp(OpGroupMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
        }
    }
}