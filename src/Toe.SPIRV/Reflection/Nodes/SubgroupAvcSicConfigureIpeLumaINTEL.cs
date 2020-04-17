using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicConfigureIpeLumaINTEL : Node
    {
        public SubgroupAvcSicConfigureIpeLumaINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcSicConfigureIpeLumaINTEL;


        public Node LumaIntraPartitionMask { get; set; }
        public Node IntraNeighbourAvailabilty { get; set; }
        public Node LeftEdgeLumaPixels { get; set; }
        public Node UpperLeftCornerLumaPixel { get; set; }
        public Node UpperEdgeLumaPixels { get; set; }
        public Node UpperRightEdgeLumaPixels { get; set; }
        public Node SadAdjustment { get; set; }
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
                yield return CreateInputPin(nameof(LumaIntraPartitionMask), LumaIntraPartitionMask);
                yield return CreateInputPin(nameof(IntraNeighbourAvailabilty), IntraNeighbourAvailabilty);
                yield return CreateInputPin(nameof(LeftEdgeLumaPixels), LeftEdgeLumaPixels);
                yield return CreateInputPin(nameof(UpperLeftCornerLumaPixel), UpperLeftCornerLumaPixel);
                yield return CreateInputPin(nameof(UpperEdgeLumaPixels), UpperEdgeLumaPixels);
                yield return CreateInputPin(nameof(UpperRightEdgeLumaPixels), UpperRightEdgeLumaPixels);
                yield return CreateInputPin(nameof(SadAdjustment), SadAdjustment);
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
            SetUp((OpSubgroupAvcSicConfigureIpeLumaINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcSicConfigureIpeLumaINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            LumaIntraPartitionMask = treeBuilder.GetNode(op.LumaIntraPartitionMask);
            IntraNeighbourAvailabilty = treeBuilder.GetNode(op.IntraNeighbourAvailabilty);
            LeftEdgeLumaPixels = treeBuilder.GetNode(op.LeftEdgeLumaPixels);
            UpperLeftCornerLumaPixel = treeBuilder.GetNode(op.UpperLeftCornerLumaPixel);
            UpperEdgeLumaPixels = treeBuilder.GetNode(op.UpperEdgeLumaPixels);
            UpperRightEdgeLumaPixels = treeBuilder.GetNode(op.UpperRightEdgeLumaPixels);
            SadAdjustment = treeBuilder.GetNode(op.SadAdjustment);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}