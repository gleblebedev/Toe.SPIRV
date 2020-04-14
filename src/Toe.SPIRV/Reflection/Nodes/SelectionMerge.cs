using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SelectionMerge : ExecutableNode, INodeWithNext
    {
        public SelectionMerge()
        {
        }

        public override Op OpCode => Op.OpSelectionMerge;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node MergeBlock { get; set; }
        public Spv.SelectionControl SelectionControl { get; set; }

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
                yield return CreateExitPin(nameof(MergeBlock), MergeBlock);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpSelectionMerge)op, treeBuilder);
        }

        public void SetUp(OpSelectionMerge op, SpirvInstructionTreeBuilder treeBuilder)
        {
            MergeBlock = treeBuilder.GetNode(op.MergeBlock);
            SelectionControl = op.SelectionControl;
        }
    }
}