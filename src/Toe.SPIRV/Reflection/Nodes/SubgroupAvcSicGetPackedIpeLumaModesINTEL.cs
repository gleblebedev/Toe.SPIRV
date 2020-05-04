using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicGetPackedIpeLumaModesINTEL : Node
    {
        public SubgroupAvcSicGetPackedIpeLumaModesINTEL()
        {
        }

        public SubgroupAvcSicGetPackedIpeLumaModesINTEL(SpirvTypeBase resultType, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcSicGetPackedIpeLumaModesINTEL;

        public Node Payload { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<Node> GetInputNodes()
        {
                yield return Payload;
        }

        public SubgroupAvcSicGetPackedIpeLumaModesINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcSicGetPackedIpeLumaModesINTEL)op, treeBuilder);
        }

        public SubgroupAvcSicGetPackedIpeLumaModesINTEL SetUp(Action<SubgroupAvcSicGetPackedIpeLumaModesINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcSicGetPackedIpeLumaModesINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcSicGetPackedIpeLumaModesINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcSicGetPackedIpeLumaModesINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcSicGetPackedIpeLumaModesINTEL({ResultType}, {Payload}, {DebugName})";
        }
    }
}