using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleINTEL : FunctionNode 
    {
        public SubgroupShuffleINTEL()
        {
        }

        public Node Data { get; set; }
        public Node InvocationId { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Data), Data);
                yield return CreateInputPin(nameof(InvocationId), InvocationId);
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
            SetUp((OpSubgroupShuffleINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupShuffleINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Data = treeBuilder.GetNode(op.Data);
            InvocationId = treeBuilder.GetNode(op.InvocationId);
        }
    }
}