using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleXorINTEL : Node
    {
        public SubgroupShuffleXorINTEL()
        {
        }

        public SubgroupShuffleXorINTEL(SpirvTypeBase resultType, Node data, Node value, string debugName = null)
        {
            this.ResultType = resultType;
            this.Data = data;
            this.Value = value;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupShuffleXorINTEL;

        public Node Data { get; set; }

        public Node Value { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Data), Data);
                yield return CreateInputPin(nameof(Value), Value);
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

        public SubgroupShuffleXorINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupShuffleXorINTEL)op, treeBuilder);
        }

        public SubgroupShuffleXorINTEL SetUp(Action<SubgroupShuffleXorINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupShuffleXorINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Data = treeBuilder.GetNode(op.Data);
            Value = treeBuilder.GetNode(op.Value);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupShuffleXorINTEL object.</summary>
        /// <returns>A string that represents the SubgroupShuffleXorINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupShuffleXorINTEL({ResultType}, {Data}, {Value}, {DebugName})";
        }
    }
}