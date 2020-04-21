using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LifetimeStart : ExecutableNode, INodeWithNext
    {
        public LifetimeStart()
        {
        }

        public LifetimeStart(Node pointer, uint size, string debugName = null)
        {
            this.Pointer = pointer;
            this.Size = size;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpLifetimeStart;

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

        public Node Pointer { get; set; }

        public uint Size { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
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

        public LifetimeStart WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpLifetimeStart)op, treeBuilder);
        }

        public LifetimeStart SetUp(Action<LifetimeStart> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpLifetimeStart op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
            Size = op.Size;
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the LifetimeStart object.</summary>
        /// <returns>A string that represents the LifetimeStart object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"LifetimeStart({Pointer}, {Size}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static LifetimeStart ThenLifetimeStart(this INodeWithNext node, Node pointer, uint size, string debugName = null)
        {
            return node.Then(new LifetimeStart(pointer, size, debugName));
        }
    }
}