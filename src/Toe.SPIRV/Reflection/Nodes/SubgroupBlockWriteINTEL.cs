using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupBlockWriteINTEL : ExecutableNode 
    {
        public SubgroupBlockWriteINTEL()
        {
        }

        public Node Ptr { get; set; }
        public Node Data { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Ptr), Ptr);
                yield return CreateInputPin(nameof(Data), Data);
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
            SetUp((OpSubgroupBlockWriteINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Ptr = treeBuilder.GetNode(op.Ptr);
            Data = treeBuilder.GetNode(op.Data);
        }
    }
}