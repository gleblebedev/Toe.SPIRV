using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicSetIntraLumaModeCostFunctionINTEL : Node
    {
        public SubgroupAvcSicSetIntraLumaModeCostFunctionINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL;


        public Node LumaModePenalty { get; set; }
        public Node LumaPackedNeighborModes { get; set; }
        public Node LumaPackedNonDcPenalty { get; set; }
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
                yield return CreateInputPin(nameof(LumaModePenalty), LumaModePenalty);
                yield return CreateInputPin(nameof(LumaPackedNeighborModes), LumaPackedNeighborModes);
                yield return CreateInputPin(nameof(LumaPackedNonDcPenalty), LumaPackedNonDcPenalty);
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
            SetUp((OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            LumaModePenalty = treeBuilder.GetNode(op.LumaModePenalty);
            LumaPackedNeighborModes = treeBuilder.GetNode(op.LumaPackedNeighborModes);
            LumaPackedNonDcPenalty = treeBuilder.GetNode(op.LumaPackedNonDcPenalty);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}