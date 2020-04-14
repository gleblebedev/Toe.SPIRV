using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CompositeInsert : FunctionNode 
    {
        public CompositeInsert()
        {
        }

        public Node Object { get; set; }
        public Node Composite { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Object), Object);
                yield return CreateInputPin(nameof(Composite), Composite);
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
            SetUp((OpCompositeInsert)op, treeBuilder);
        }

        public void SetUp(OpCompositeInsert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Object = treeBuilder.GetNode(op.Object);
            Composite = treeBuilder.GetNode(op.Composite);
        }
    }
}