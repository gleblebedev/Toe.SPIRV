using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL : Node
    {
        public SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL()
        {
        }

        public SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL(SpirvTypeBase resultType, Node sliceType, Node qp, string debugName = null)
        {
            this.ResultType = resultType;
            this.SliceType = sliceType;
            this.Qp = qp;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL;

        public Node SliceType { get; set; }

        public Node Qp { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SliceType), SliceType);
                yield return CreateInputPin(nameof(Qp), Qp);
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

        public SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL)op, treeBuilder);
        }

        public SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL SetUp(Action<SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SliceType = treeBuilder.GetNode(op.SliceType);
            Qp = treeBuilder.GetNode(op.Qp);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL({ResultType}, {SliceType}, {Qp}, {DebugName})";
        }
    }
}