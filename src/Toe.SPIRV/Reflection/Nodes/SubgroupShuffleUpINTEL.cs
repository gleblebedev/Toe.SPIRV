using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleUpINTEL : FunctionNode 
    {
        public SubgroupShuffleUpINTEL()
        {
        }

        public Node Previous { get; set; }
        public Node Current { get; set; }
        public Node Delta { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Previous), Previous);
                yield return CreateInputPin(nameof(Current), Current);
                yield return CreateInputPin(nameof(Delta), Delta);
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
            SetUp((OpSubgroupShuffleUpINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupShuffleUpINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Previous = treeBuilder.GetNode(op.Previous);
            Current = treeBuilder.GetNode(op.Current);
            Delta = treeBuilder.GetNode(op.Delta);
        }
    }
}