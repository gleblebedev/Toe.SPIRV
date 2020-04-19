using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LoopMerge : ExecutableNode, INodeWithNext
    {
        public LoopMerge()
        {
        }

        public override Op OpCode => Op.OpLoopMerge;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Label MergeBlock { get; set; }
        public Node ContinueTarget { get; set; }
        public Spv.LoopControl LoopControl { get; set; }

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
                yield return CreateExitPin(nameof(ContinueTarget), ContinueTarget);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpLoopMerge)op, treeBuilder);
        }

        public void SetUp(OpLoopMerge op, SpirvInstructionTreeBuilder treeBuilder)
        {
            MergeBlock = (Label)treeBuilder.GetNode(op.MergeBlock);
            ContinueTarget = treeBuilder.GetNode(op.ContinueTarget);
            LoopControl = op.LoopControl;
            SetUpDecorations(op, treeBuilder);
        }
    }
}