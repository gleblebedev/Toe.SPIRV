using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleXorINTEL : FunctionNode 
    {
        public SubgroupShuffleXorINTEL()
        {
        }

        public Node Data { get; set; }
        public Node Value { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Data), Data);
                yield return CreateInputPin(nameof(Value), Value);
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
            SetUp((OpSubgroupShuffleXorINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupShuffleXorINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Data = treeBuilder.GetNode(op.Data);
            Value = treeBuilder.GetNode(op.Value);
        }
    }
}