using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BranchConditional : ExecutableNode
    {
        public BranchConditional()
        {
        }

        public override Op OpCode => Op.OpBranchConditional;


        public Node Condition { get; set; }
        public Label TrueLabel { get; set; }
        public Label FalseLabel { get; set; }
        public IList<uint> Branchweights { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Condition), Condition);
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
                yield return CreateExitPin(nameof(TrueLabel), TrueLabel);
                yield return CreateExitPin(nameof(FalseLabel), FalseLabel);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpBranchConditional)op, treeBuilder);
        }

        public void SetUp(OpBranchConditional op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Condition = treeBuilder.GetNode(op.Condition);
            TrueLabel = (Label)treeBuilder.GetNode(op.TrueLabel);
            FalseLabel = (Label)treeBuilder.GetNode(op.FalseLabel);
            Branchweights = op.Branchweights;
        }
    }
}