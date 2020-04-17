using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcMceSetMotionVectorCostFunctionINTEL : Node
    {
        public SubgroupAvcMceSetMotionVectorCostFunctionINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL;


        public Node PackedCostCenterDelta { get; set; }
        public Node PackedCostTable { get; set; }
        public Node CostPrecision { get; set; }
        public Node Payload { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public bool RelaxedPrecision { get; set; }

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
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            PackedCostCenterDelta = treeBuilder.GetNode(op.PackedCostCenterDelta);
            PackedCostTable = treeBuilder.GetNode(op.PackedCostTable);
            CostPrecision = treeBuilder.GetNode(op.CostPrecision);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}