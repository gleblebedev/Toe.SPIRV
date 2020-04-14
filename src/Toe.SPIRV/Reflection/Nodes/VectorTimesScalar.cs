using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorTimesScalar : FunctionNode 
    {
        public VectorTimesScalar()
        {
        }

        public Node Vector { get; set; }
        public Node Scalar { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Vector), Vector);
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
            SetUp((OpVectorTimesScalar)op, treeBuilder);
        }

        public void SetUp(OpVectorTimesScalar op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Scalar = treeBuilder.GetNode(op.Scalar);
        }
    }
}