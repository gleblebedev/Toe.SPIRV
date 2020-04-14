using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BranchConditional : ExecutableNode 
    {
        public BranchConditional()
        {
        }

        public Node Condition { get; set; }
        public ExecutableNode TrueLabel { get; set; }
        public ExecutableNode FalseLabel { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Condition), Condition);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
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
            TrueLabel = (ExecutableNode)treeBuilder.GetNode(op.TrueLabel);
            FalseLabel = (ExecutableNode)treeBuilder.GetNode(op.FalseLabel);
        }
    }
}