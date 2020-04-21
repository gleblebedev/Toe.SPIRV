using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Branch : ExecutableNode
    {
        public Branch()
        {
        }

        public Branch(Label targetLabel, string debugName = null)
        {
            this.TargetLabel = targetLabel;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpBranch;

        public Label TargetLabel { get; set; }

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
                yield return CreateExitPin(nameof(TargetLabel), TargetLabel);
                yield break;
            }
        }

        public Branch WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpBranch)op, treeBuilder);
        }

        public Branch SetUp(Action<Branch> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpBranch op, SpirvInstructionTreeBuilder treeBuilder)
        {
            TargetLabel = (Label)treeBuilder.GetNode(op.TargetLabel);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Branch object.</summary>
        /// <returns>A string that represents the Branch object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Branch({TargetLabel}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static Branch ThenBranch(this INodeWithNext node, Label targetLabel, string debugName = null)
        {
            return node.Then(new Branch(targetLabel, debugName));
        }
    }
}