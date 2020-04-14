using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorInsertDynamic : FunctionNode 
    {
        public VectorInsertDynamic()
        {
        }

        public Node Vector { get; set; }
        public Node Component { get; set; }
        public Node Index { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Vector), Vector);
                yield return CreateInputPin(nameof(Component), Component);
                yield return CreateInputPin(nameof(Index), Index);
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
            SetUp((OpVectorInsertDynamic)op, treeBuilder);
        }

        public void SetUp(OpVectorInsertDynamic op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Component = treeBuilder.GetNode(op.Component);
            Index = treeBuilder.GetNode(op.Index);
        }
    }
}