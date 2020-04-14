using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicCompareExchange : FunctionNode 
    {
        public AtomicCompareExchange()
        {
        }

        public Node Pointer { get; set; }
        public Node Value { get; set; }
        public Node Comparator { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
                yield return CreateInputPin(nameof(Value), Value);
                yield return CreateInputPin(nameof(Comparator), Comparator);
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
            SetUp((OpAtomicCompareExchange)op, treeBuilder);
        }

        public void SetUp(OpAtomicCompareExchange op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            Value = treeBuilder.GetNode(op.Value);
            Comparator = treeBuilder.GetNode(op.Comparator);
        }
    }
}