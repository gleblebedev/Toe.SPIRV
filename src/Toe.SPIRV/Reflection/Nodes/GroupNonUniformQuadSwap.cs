using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupNonUniformQuadSwap : Node
    {
        public GroupNonUniformQuadSwap()
        {
        }

        public GroupNonUniformQuadSwap(SpirvTypeBase resultType, uint execution, Node value, Node direction, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Value = value;
            this.Direction = direction;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupNonUniformQuadSwap;

        public uint Execution { get; set; }

        public Node Value { get; set; }

        public Node Direction { get; set; }

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
                yield return CreateInputPin(nameof(Direction), Direction);
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

        public GroupNonUniformQuadSwap WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupNonUniformQuadSwap)op, treeBuilder);
        }

        public GroupNonUniformQuadSwap SetUp(Action<GroupNonUniformQuadSwap> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupNonUniformQuadSwap op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Value = treeBuilder.GetNode(op.Value);
            Direction = treeBuilder.GetNode(op.Direction);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupNonUniformQuadSwap object.</summary>
        /// <returns>A string that represents the GroupNonUniformQuadSwap object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupNonUniformQuadSwap({ResultType}, {Execution}, {Value}, {Direction}, {DebugName})";
        }
    }
}