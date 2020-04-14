using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleDownINTEL : FunctionNode 
    {
        public SubgroupShuffleDownINTEL()
        {
        }

        public Node Current { get; set; }
        public Node Next { get; set; }
        public Node Delta { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Current), Current);
                yield return CreateInputPin(nameof(Next), Next);
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
            SetUp((OpSubgroupShuffleDownINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupShuffleDownINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Current = treeBuilder.GetNode(op.Current);
            Next = treeBuilder.GetNode(op.Next);
            Delta = treeBuilder.GetNode(op.Delta);
        }
    }
}