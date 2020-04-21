using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeSetDualReferenceINTEL : Node
    {
        public SubgroupAvcImeSetDualReferenceINTEL()
        {
        }

        public SubgroupAvcImeSetDualReferenceINTEL(SpirvTypeBase resultType, Node fwdRefOffset, Node bwdRefOffset, Node searchWindowConfig, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.FwdRefOffset = fwdRefOffset;
            this.BwdRefOffset = bwdRefOffset;
            this.SearchWindowConfig = searchWindowConfig;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeSetDualReferenceINTEL;

        public Node FwdRefOffset { get; set; }

        public Node BwdRefOffset { get; set; }

        public Node SearchWindowConfig { get; set; }

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
                yield return CreateInputPin(nameof(FwdRefOffset), FwdRefOffset);
                yield return CreateInputPin(nameof(BwdRefOffset), BwdRefOffset);
                yield return CreateInputPin(nameof(SearchWindowConfig), SearchWindowConfig);
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

        public SubgroupAvcImeSetDualReferenceINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeSetDualReferenceINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeSetDualReferenceINTEL SetUp(Action<SubgroupAvcImeSetDualReferenceINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeSetDualReferenceINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            FwdRefOffset = treeBuilder.GetNode(op.FwdRefOffset);
            BwdRefOffset = treeBuilder.GetNode(op.BwdRefOffset);
            SearchWindowConfig = treeBuilder.GetNode(op.SearchWindowConfig);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeSetDualReferenceINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeSetDualReferenceINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeSetDualReferenceINTEL({ResultType}, {FwdRefOffset}, {BwdRefOffset}, {SearchWindowConfig}, {Payload}, {DebugName})";
        }
    }
}