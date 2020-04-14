using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Branch : ExecutableNode 
    {
        public Branch()
        {
        }

        public ExecutableNode TargetLabel { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
                yield return CreateExitPin(nameof(TargetLabel), TargetLabel);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpBranch)op, treeBuilder);
        }

        public void SetUp(OpBranch op, SpirvInstructionTreeBuilder treeBuilder)
        {
            TargetLabel = (ExecutableNode)treeBuilder.GetNode(op.TargetLabel);
        }
    }
}