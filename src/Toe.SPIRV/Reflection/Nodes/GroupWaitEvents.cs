using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupWaitEvents : ExecutableNode, INodeWithNext
    {
        public GroupWaitEvents()
        {
        }

        public GroupWaitEvents(uint execution, Node numEvents, Node eventsList, string debugName = null)
        {
            this.Execution = execution;
            this.NumEvents = numEvents;
            this.EventsList = eventsList;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupWaitEvents;

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

        public uint Execution { get; set; }

        public Node NumEvents { get; set; }

        public Node EventsList { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(NumEvents), NumEvents);
                yield return CreateInputPin(nameof(EventsList), EventsList);
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

        public GroupWaitEvents WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupWaitEvents)op, treeBuilder);
        }

        public GroupWaitEvents SetUp(Action<GroupWaitEvents> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupWaitEvents op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Execution = op.Execution;
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            EventsList = treeBuilder.GetNode(op.EventsList);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupWaitEvents object.</summary>
        /// <returns>A string that represents the GroupWaitEvents object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupWaitEvents({Execution}, {NumEvents}, {EventsList}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static GroupWaitEvents ThenGroupWaitEvents(this INodeWithNext node, uint execution, Node numEvents, Node eventsList, string debugName = null)
        {
            return node.Then(new GroupWaitEvents(execution, numEvents, eventsList, debugName));
        }
    }
}