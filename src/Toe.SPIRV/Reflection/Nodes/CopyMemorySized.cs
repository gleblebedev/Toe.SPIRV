using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CopyMemorySized : ExecutableNode, INodeWithNext
    {
        public CopyMemorySized()
        {
        }

        public CopyMemorySized(Node target, Node source, Node size, Spv.MemoryAccess memoryAccess, Spv.MemoryAccess memoryAccess2, string debugName = null)
        {
            this.Target = target;
            this.Source = source;
            this.Size = size;
            this.MemoryAccess = memoryAccess;
            this.MemoryAccess2 = memoryAccess2;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpCopyMemorySized;

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

        public Node Target { get; set; }

        public Node Source { get; set; }

        public Node Size { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }

        public Spv.MemoryAccess MemoryAccess2 { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Target), Target);
                yield return CreateInputPin(nameof(Source), Source);
                yield return CreateInputPin(nameof(Size), Size);
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

        public CopyMemorySized WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpCopyMemorySized)op, treeBuilder);
        }

        public CopyMemorySized SetUp(Action<CopyMemorySized> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpCopyMemorySized op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Source = treeBuilder.GetNode(op.Source);
            Size = treeBuilder.GetNode(op.Size);
            MemoryAccess = op.MemoryAccess;
            MemoryAccess2 = op.MemoryAccess2;
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the CopyMemorySized object.</summary>
        /// <returns>A string that represents the CopyMemorySized object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"CopyMemorySized({Target}, {Source}, {Size}, {MemoryAccess}, {MemoryAccess2}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static CopyMemorySized ThenCopyMemorySized(this INodeWithNext node, Node target, Node source, Node size, Spv.MemoryAccess memoryAccess, Spv.MemoryAccess memoryAccess2, string debugName = null)
        {
            return node.Then(new CopyMemorySized(target, source, size, memoryAccess, memoryAccess2, debugName));
        }
    }
}