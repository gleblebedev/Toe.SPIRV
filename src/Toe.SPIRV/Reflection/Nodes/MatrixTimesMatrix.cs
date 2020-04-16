using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesMatrix : Node
    {
        public MatrixTimesMatrix()
        {
        }

        public override Op OpCode => Op.OpMatrixTimesMatrix;


        public Node LeftMatrix { get; set; }
        public Node RightMatrix { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(LeftMatrix), LeftMatrix);
                yield return CreateInputPin(nameof(RightMatrix), RightMatrix);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield return new NodePin(this, "", ResultType);
                yield break;
            }
        }


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
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
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}