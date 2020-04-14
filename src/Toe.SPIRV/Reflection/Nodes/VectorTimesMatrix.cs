using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorTimesMatrix : FunctionNode 
    {
        public VectorTimesMatrix()
        {
        }

        public Node Vector { get; set; }
        public Node Matrix { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Vector), Vector);
                yield return CreateInputPin(nameof(Matrix), Matrix);
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
            SetUp((OpVectorTimesMatrix)op, treeBuilder);
        }

        public void SetUp(OpVectorTimesMatrix op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Matrix = treeBuilder.GetNode(op.Matrix);
        }
    }
}