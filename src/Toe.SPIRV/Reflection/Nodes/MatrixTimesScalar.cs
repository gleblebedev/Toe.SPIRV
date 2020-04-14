using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesScalar : FunctionNode 
    {
        public MatrixTimesScalar()
        {
        }

        public Node Matrix { get; set; }
        public Node Scalar { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Matrix), Matrix);
                yield return CreateInputPin(nameof(Scalar), Scalar);
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
            SetUp((OpMatrixTimesScalar)op, treeBuilder);
        }

        public void SetUp(OpMatrixTimesScalar op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Matrix = treeBuilder.GetNode(op.Matrix);
            Scalar = treeBuilder.GetNode(op.Scalar);
        }
    }
}