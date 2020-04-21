using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupNonUniformShuffleUp : Node
    {
        public GroupNonUniformShuffleUp()
        {
        }

        public GroupNonUniformShuffleUp(SpirvTypeBase resultType, uint execution, Node value, Node delta, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Value = value;
            this.Delta = delta;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupNonUniformShuffleUp;

        public uint Execution { get; set; }

        public Node Value { get; set; }

        public Node Delta { get; set; }

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
                yield return CreateInputPin(nameof(Delta), Delta);
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

        public GroupNonUniformShuffleUp WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupNonUniformShuffleUp)op, treeBuilder);
        }

        public GroupNonUniformShuffleUp SetUp(Action<GroupNonUniformShuffleUp> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupNonUniformShuffleUp op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Value = treeBuilder.GetNode(op.Value);
            Delta = treeBuilder.GetNode(op.Delta);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupNonUniformShuffleUp object.</summary>
        /// <returns>A string that represents the GroupNonUniformShuffleUp object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupNonUniformShuffleUp({ResultType}, {Execution}, {Value}, {Delta}, {DebugName})";
        }
    }
}