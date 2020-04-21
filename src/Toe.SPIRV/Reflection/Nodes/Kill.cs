using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Kill : ExecutableNode
    {
        public Kill()
        {
        }

        public Kill(string debugName = null)
        {
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpKill;

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

        public Kill WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpKill)op, treeBuilder);
        }

        public Kill SetUp(Action<Kill> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpKill op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Kill object.</summary>
        /// <returns>A string that represents the Kill object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Kill({DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static Kill ThenKill(this INodeWithNext node, string debugName = null)
        {
            return node.Then(new Kill(debugName));
        }
    }
}