using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesVector : FunctionNode 
    {
        public MatrixTimesVector()
        {
        }

        public Node Matrix { get; set; }
        public Node Vector { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Matrix), Matrix);
                yield return CreateInputPin(nameof(Vector), Vector);
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
            SetUp((OpMatrixTimesVector)op, treeBuilder);
        }

        public void SetUp(OpMatrixTimesVector op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Matrix = treeBuilder.GetNode(op.Matrix);
            Vector = treeBuilder.GetNode(op.Vector);
        }
    }
}