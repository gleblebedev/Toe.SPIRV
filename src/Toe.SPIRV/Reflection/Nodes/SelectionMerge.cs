using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SelectionMerge : ExecutableNode 
    {
        public SelectionMerge()
        {
        }

        public ExecutableNode MergeBlock { get; set; }
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
                yield return CreateExitPin(nameof(MergeBlock), MergeBlock);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpSelectionMerge)op, treeBuilder);
        }

        public void SetUp(OpSelectionMerge op, SpirvInstructionTreeBuilder treeBuilder)
        {
            MergeBlock = (ExecutableNode)treeBuilder.GetNode(op.MergeBlock);
        }
    }
}