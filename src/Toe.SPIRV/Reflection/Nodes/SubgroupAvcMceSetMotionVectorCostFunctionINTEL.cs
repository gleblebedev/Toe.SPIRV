using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcMceSetMotionVectorCostFunctionINTEL : Node
    {
        public SubgroupAvcMceSetMotionVectorCostFunctionINTEL()
        {
        }

        public SubgroupAvcMceSetMotionVectorCostFunctionINTEL(SpirvTypeBase resultType, Node packedCostCenterDelta, Node packedCostTable, Node costPrecision, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.PackedCostCenterDelta = packedCostCenterDelta;
            this.PackedCostTable = packedCostTable;
            this.CostPrecision = costPrecision;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL;

        public Node PackedCostCenterDelta { get; set; }

        public Node PackedCostTable { get; set; }

        public Node CostPrecision { get; set; }

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
                yield return CreateInputPin(nameof(PackedCostCenterDelta), PackedCostCenterDelta);
                yield return CreateInputPin(nameof(PackedCostTable), PackedCostTable);
                yield return CreateInputPin(nameof(CostPrecision), CostPrecision);
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

        public SubgroupAvcMceSetMotionVectorCostFunctionINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL)op, treeBuilder);
        }

        public SubgroupAvcMceSetMotionVectorCostFunctionINTEL SetUp(Action<SubgroupAvcMceSetMotionVectorCostFunctionINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            PackedCostCenterDelta = treeBuilder.GetNode(op.PackedCostCenterDelta);
            PackedCostTable = treeBuilder.GetNode(op.PackedCostTable);
            CostPrecision = treeBuilder.GetNode(op.CostPrecision);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcMceSetMotionVectorCostFunctionINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcMceSetMotionVectorCostFunctionINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcMceSetMotionVectorCostFunctionINTEL({ResultType}, {PackedCostCenterDelta}, {PackedCostTable}, {CostPrecision}, {Payload}, {DebugName})";
        }
    }
}