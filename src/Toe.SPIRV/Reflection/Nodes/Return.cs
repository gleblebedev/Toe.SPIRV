using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Return : ExecutableNode
    {
        public Return()
        {
        }

        public Return(string debugName = null)
        {
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpReturn;

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
                yield break;
            }
        }

        public Return WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpReturn)op, treeBuilder);
        }

        public Return SetUp(Action<Return> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpReturn op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Return object.</summary>
        /// <returns>A string that represents the Return object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Return({DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static Return ThenReturn(this INodeWithNext node, string debugName = null)
        {
            return node.Then(new Return(debugName));
        }
    }
}