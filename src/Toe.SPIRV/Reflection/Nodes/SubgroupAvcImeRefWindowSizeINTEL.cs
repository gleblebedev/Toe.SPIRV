using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeRefWindowSizeINTEL : Node
    {
        public SubgroupAvcImeRefWindowSizeINTEL()
        {
        }

        public SubgroupAvcImeRefWindowSizeINTEL(SpirvTypeBase resultType, Node searchWindowConfig, Node dualRef, string debugName = null)
        {
            this.ResultType = resultType;
            this.SearchWindowConfig = searchWindowConfig;
            this.DualRef = dualRef;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeRefWindowSizeINTEL;

        public Node SearchWindowConfig { get; set; }

        public Node DualRef { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SearchWindowConfig), SearchWindowConfig);
                yield return CreateInputPin(nameof(DualRef), DualRef);
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

        public SubgroupAvcImeRefWindowSizeINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeRefWindowSizeINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeRefWindowSizeINTEL SetUp(Action<SubgroupAvcImeRefWindowSizeINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeRefWindowSizeINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SearchWindowConfig = treeBuilder.GetNode(op.SearchWindowConfig);
            DualRef = treeBuilder.GetNode(op.DualRef);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeRefWindowSizeINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeRefWindowSizeINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeRefWindowSizeINTEL({ResultType}, {SearchWindowConfig}, {DualRef}, {DebugName})";
        }
    }
}