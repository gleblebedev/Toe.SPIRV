using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Branch : ExecutableNode
    {
        public Branch()
        {
        }

        public override Op OpCode => Op.OpBranch;


        public Label TargetLabel { get; set; }

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
            TargetLabel = (Label)treeBuilder.GetNode(op.TargetLabel);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}