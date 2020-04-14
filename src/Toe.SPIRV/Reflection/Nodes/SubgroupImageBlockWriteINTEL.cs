using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupImageBlockWriteINTEL : ExecutableNode 
    {
        public SubgroupImageBlockWriteINTEL()
        {
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Data { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
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
            SetUp((OpSubgroupImageBlockWriteINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupImageBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Data = treeBuilder.GetNode(op.Data);
        }
    }
}