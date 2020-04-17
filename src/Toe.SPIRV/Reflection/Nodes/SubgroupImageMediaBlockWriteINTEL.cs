using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupImageMediaBlockWriteINTEL : ExecutableNode, INodeWithNext
    {
        public SubgroupImageMediaBlockWriteINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupImageMediaBlockWriteINTEL;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Width { get; set; }
        public Node Height { get; set; }
        public Node Data { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(Width), Width);
                yield return CreateInputPin(nameof(Height), Height);
                yield return CreateInputPin(nameof(Data), Data);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> EnterPins
        {
            get
            {
                yield return new NodePin(this, "", null);
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpSubgroupImageMediaBlockWriteINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupImageMediaBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Width = treeBuilder.GetNode(op.Width);
            Height = treeBuilder.GetNode(op.Height);
            Data = treeBuilder.GetNode(op.Data);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}