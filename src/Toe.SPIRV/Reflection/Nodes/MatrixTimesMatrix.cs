using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesMatrix : FunctionNode 
    {
        public MatrixTimesMatrix()
        {
        }

        public Node LeftMatrix { get; set; }
        public Node RightMatrix { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(LeftMatrix), LeftMatrix);
                yield return CreateInputPin(nameof(RightMatrix), RightMatrix);
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
            SetUp((OpMatrixTimesMatrix)op, treeBuilder);
        }

        public void SetUp(OpMatrixTimesMatrix op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            LeftMatrix = treeBuilder.GetNode(op.LeftMatrix);
            RightMatrix = treeBuilder.GetNode(op.RightMatrix);
        }
    }
}