using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class TerminateRayNV : ExecutableNode, INodeWithNext
    {
        public TerminateRayNV()
        {
        }

        public TerminateRayNV(string debugName = null)
        {
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpTerminateRayNV;

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

        public TerminateRayNV WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTerminateRayNV)op, treeBuilder);
        }

        public TerminateRayNV SetUp(Action<TerminateRayNV> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpTerminateRayNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the TerminateRayNV object.</summary>
        /// <returns>A string that represents the TerminateRayNV object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"TerminateRayNV({DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static TerminateRayNV ThenTerminateRayNV(this INodeWithNext node, string debugName = null)
        {
            return node.Then(new TerminateRayNV(debugName));
        }
    }
}