using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorate : ExecutableNode 
    {
        public MemberDecorate()
        {
        }

        public Node StructureType { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(StructureType), StructureType);
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
            SetUp((OpMemberDecorate)op, treeBuilder);
        }

        public void SetUp(OpMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructureType = treeBuilder.GetNode(op.StructureType);
        }
    }
}