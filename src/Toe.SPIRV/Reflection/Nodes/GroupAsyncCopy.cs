using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupAsyncCopy : Node
    {
        public GroupAsyncCopy()
        {
        }

        public GroupAsyncCopy(SpirvTypeBase resultType, uint execution, Node destination, Node source, Node numElements, Node stride, Node @event, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Destination = destination;
            this.Source = source;
            this.NumElements = numElements;
            this.Stride = stride;
            this.Event = @event;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupAsyncCopy;

        public uint Execution { get; set; }

        public Node Destination { get; set; }

        public Node Source { get; set; }

        public Node NumElements { get; set; }

        public Node Stride { get; set; }

        public Node Event { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Destination), Destination);
                yield return CreateInputPin(nameof(Source), Source);
                yield return CreateInputPin(nameof(NumElements), NumElements);
                yield return CreateInputPin(nameof(Stride), Stride);
                yield return CreateInputPin(nameof(Event), Event);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield return new NodePin(this, "", ResultType);
                yield break;
            }
        }


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }

        public GroupAsyncCopy WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupAsyncCopy)op, treeBuilder);
        }

        public GroupAsyncCopy SetUp(Action<GroupAsyncCopy> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupAsyncCopy op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Destination = treeBuilder.GetNode(op.Destination);
            Source = treeBuilder.GetNode(op.Source);
            NumElements = treeBuilder.GetNode(op.NumElements);
            Stride = treeBuilder.GetNode(op.Stride);
            Event = treeBuilder.GetNode(op.Event);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupAsyncCopy object.</summary>
        /// <returns>A string that represents the GroupAsyncCopy object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupAsyncCopy({ResultType}, {Execution}, {Destination}, {Source}, {NumElements}, {Stride}, {Event}, {DebugName})";
        }
    }
}