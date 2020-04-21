using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReleaseEvent : ExecutableNode, INodeWithNext
    {
        public ReleaseEvent()
        {
        }

        public ReleaseEvent(Node @event, string debugName = null)
        {
            this.Event = @event;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpReleaseEvent;

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

        public Node Event { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Event), Event);
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

        public ReleaseEvent WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpReleaseEvent)op, treeBuilder);
        }

        public ReleaseEvent SetUp(Action<ReleaseEvent> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpReleaseEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Event = treeBuilder.GetNode(op.Event);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the ReleaseEvent object.</summary>
        /// <returns>A string that represents the ReleaseEvent object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"ReleaseEvent({Event}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static ReleaseEvent ThenReleaseEvent(this INodeWithNext node, Node @event, string debugName = null)
        {
            return node.Then(new ReleaseEvent(@event, debugName));
        }
    }
}