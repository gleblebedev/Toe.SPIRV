using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorateStringGOOGLE : ExecutableNode 
    {
        public MemberDecorateStringGOOGLE()
        {
        }

        public Node StructType { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(StructType), StructType);
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
            SetUp((OpMemberDecorateStringGOOGLE)op, treeBuilder);
        }

        public void SetUp(OpMemberDecorateStringGOOGLE op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructType = treeBuilder.GetNode(op.StructType);
        }
    }
}