using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Label : ExecutableNode, INodeWithNext
    {
        public Label()
        {
        }

        public Label(string debugName = null)
        {
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpLabel;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public T Then<T>(T node) where T: ExecutableNode
        {
            Next = node;
            return node;
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

        public Label WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpLabel)op, treeBuilder);
        }

        public Label SetUp(Action<Label> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpLabel op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Label object.</summary>
        /// <returns>A string that represents the Label object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Label({DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static Label ThenLabel(this INodeWithNext node, string debugName = null)
        {
            return node.Then(new Label(debugName));
        }
    }
}