using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupNonUniformBroadcast : Node
    {
        public GroupNonUniformBroadcast()
        {
        }

        public GroupNonUniformBroadcast(SpirvTypeBase resultType, uint execution, Node value, Node id, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Value = value;
            this.Id = id;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupNonUniformBroadcast;

        public uint Execution { get; set; }

        public Node Value { get; set; }

        public Node Id { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Value), Value);
                yield return CreateInputPin(nameof(Id), Id);
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

        public GroupNonUniformBroadcast WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupNonUniformBroadcast)op, treeBuilder);
        }

        public GroupNonUniformBroadcast SetUp(Action<GroupNonUniformBroadcast> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupNonUniformBroadcast op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Value = treeBuilder.GetNode(op.Value);
            Id = treeBuilder.GetNode(op.Id);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupNonUniformBroadcast object.</summary>
        /// <returns>A string that represents the GroupNonUniformBroadcast object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupNonUniformBroadcast({ResultType}, {Execution}, {Value}, {Id}, {DebugName})";
        }
    }
}