using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicSetIntraLumaShapePenaltyINTEL : Node
    {
        public SubgroupAvcSicSetIntraLumaShapePenaltyINTEL()
        {
        }

        public SubgroupAvcSicSetIntraLumaShapePenaltyINTEL(SpirvTypeBase resultType, Node packedShapePenalty, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.PackedShapePenalty = packedShapePenalty;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL;

        public Node PackedShapePenalty { get; set; }

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
                yield return CreateInputPin(nameof(PackedShapePenalty), PackedShapePenalty);
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

        public SubgroupAvcSicSetIntraLumaShapePenaltyINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL)op, treeBuilder);
        }

        public SubgroupAvcSicSetIntraLumaShapePenaltyINTEL SetUp(Action<SubgroupAvcSicSetIntraLumaShapePenaltyINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            PackedShapePenalty = treeBuilder.GetNode(op.PackedShapePenalty);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcSicSetIntraLumaShapePenaltyINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcSicSetIntraLumaShapePenaltyINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcSicSetIntraLumaShapePenaltyINTEL({ResultType}, {PackedShapePenalty}, {Payload}, {DebugName})";
        }
    }
}