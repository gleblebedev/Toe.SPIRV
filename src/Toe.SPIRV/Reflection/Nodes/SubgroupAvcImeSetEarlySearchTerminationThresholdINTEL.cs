using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL : Node
    {
        public SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL()
        {
        }

        public SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL(SpirvTypeBase resultType, Node threshold, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.Threshold = threshold;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL;

        public Node Threshold { get; set; }

        public Node Payload { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Threshold), Threshold);
                yield return CreateInputPin(nameof(Payload), Payload);
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

        public SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL SetUp(Action<SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Threshold = treeBuilder.GetNode(op.Threshold);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL({ResultType}, {Threshold}, {Payload}, {DebugName})";
        }
    }
}