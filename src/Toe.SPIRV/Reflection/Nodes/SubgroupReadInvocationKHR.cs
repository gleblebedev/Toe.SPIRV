using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupReadInvocationKHR : FunctionNode 
    {
        public SubgroupReadInvocationKHR()
        {
        }

        public Node Value { get; set; }
        public Node Index { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Value), Value);
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
            SetUp((OpSubgroupReadInvocationKHR)op, treeBuilder);
        }

        public void SetUp(OpSubgroupReadInvocationKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Value = treeBuilder.GetNode(op.Value);
            Index = treeBuilder.GetNode(op.Index);
        }
    }
}