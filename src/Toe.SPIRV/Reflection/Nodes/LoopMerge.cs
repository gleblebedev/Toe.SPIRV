using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LoopMerge : ExecutableNode 
    {
        public LoopMerge()
        {
        }

        public Node MergeBlock { get; set; }
        public Node ContinueTarget { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(MergeBlock), MergeBlock);
                yield return CreateInputPin(nameof(ContinueTarget), ContinueTarget);
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
            SetUp((OpLoopMerge)op, treeBuilder);
        }

        public void SetUp(OpLoopMerge op, SpirvInstructionTreeBuilder treeBuilder)
        {
            MergeBlock = treeBuilder.GetNode(op.MergeBlock);
            ContinueTarget = treeBuilder.GetNode(op.ContinueTarget);
        }
    }
}