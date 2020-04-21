using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EmitStreamVertex : ExecutableNode, INodeWithNext
    {
        public EmitStreamVertex()
        {
        }

        public EmitStreamVertex(Node stream, string debugName = null)
        {
            this.Stream = stream;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpEmitStreamVertex;

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

        public Node Stream { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Stream), Stream);
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

        public EmitStreamVertex WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpEmitStreamVertex)op, treeBuilder);
        }

        public EmitStreamVertex SetUp(Action<EmitStreamVertex> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpEmitStreamVertex op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Stream = treeBuilder.GetNode(op.Stream);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the EmitStreamVertex object.</summary>
        /// <returns>A string that represents the EmitStreamVertex object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"EmitStreamVertex({Stream}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static EmitStreamVertex ThenEmitStreamVertex(this INodeWithNext node, Node stream, string debugName = null)
        {
            return node.Then(new EmitStreamVertex(stream, debugName));
        }
    }
}