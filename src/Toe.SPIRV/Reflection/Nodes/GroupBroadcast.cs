using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupBroadcast : FunctionNode 
    {
        public GroupBroadcast()
        {
        }

        public Node Value { get; set; }
        public Node LocalId { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Value), Value);
                yield return CreateInputPin(nameof(LocalId), LocalId);
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
            SetUp((OpGroupBroadcast)op, treeBuilder);
        }

        public void SetUp(OpGroupBroadcast op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Value = treeBuilder.GetNode(op.Value);
            LocalId = treeBuilder.GetNode(op.LocalId);
        }
    }
}