using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleUpINTEL : Node
    {
        public SubgroupShuffleUpINTEL()
        {
        }

        public SubgroupShuffleUpINTEL(SpirvTypeBase resultType, Node previous, Node current, Node delta, string debugName = null)
        {
            this.ResultType = resultType;
            this.Previous = previous;
            this.Current = current;
            this.Delta = delta;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupShuffleUpINTEL;

        public Node Previous { get; set; }

        public Node Current { get; set; }

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
                yield return CreateInputPin(nameof(Previous), Previous);
                yield return CreateInputPin(nameof(Current), Current);
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

        public SubgroupShuffleUpINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupShuffleUpINTEL)op, treeBuilder);
        }

        public SubgroupShuffleUpINTEL SetUp(Action<SubgroupShuffleUpINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupShuffleUpINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Previous = treeBuilder.GetNode(op.Previous);
            Current = treeBuilder.GetNode(op.Current);
            Delta = treeBuilder.GetNode(op.Delta);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupShuffleUpINTEL object.</summary>
        /// <returns>A string that represents the SubgroupShuffleUpINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupShuffleUpINTEL({ResultType}, {Previous}, {Current}, {Delta}, {DebugName})";
        }
    }
}