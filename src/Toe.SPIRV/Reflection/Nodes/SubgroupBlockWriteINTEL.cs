using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupBlockWriteINTEL : ExecutableNode, INodeWithNext
    {
        public SubgroupBlockWriteINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupBlockWriteINTEL;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
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
            SetUp((OpSubgroupBlockWriteINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Ptr = treeBuilder.GetNode(op.Ptr);
            Data = treeBuilder.GetNode(op.Data);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}