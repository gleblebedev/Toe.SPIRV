using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicConfigureIpeLumaChromaINTEL : Node
    {
        public SubgroupAvcSicConfigureIpeLumaChromaINTEL()
        {
        }

        public SubgroupAvcSicConfigureIpeLumaChromaINTEL(SpirvTypeBase resultType, Node lumaIntraPartitionMask, Node intraNeighbourAvailabilty, Node leftEdgeLumaPixels, Node upperLeftCornerLumaPixel, Node upperEdgeLumaPixels, Node upperRightEdgeLumaPixels, Node leftEdgeChromaPixels, Node upperLeftCornerChromaPixel, Node upperEdgeChromaPixels, Node sadAdjustment, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.LumaIntraPartitionMask = lumaIntraPartitionMask;
            this.IntraNeighbourAvailabilty = intraNeighbourAvailabilty;
            this.LeftEdgeLumaPixels = leftEdgeLumaPixels;
            this.UpperLeftCornerLumaPixel = upperLeftCornerLumaPixel;
            this.UpperEdgeLumaPixels = upperEdgeLumaPixels;
            this.UpperRightEdgeLumaPixels = upperRightEdgeLumaPixels;
            this.LeftEdgeChromaPixels = leftEdgeChromaPixels;
            this.UpperLeftCornerChromaPixel = upperLeftCornerChromaPixel;
            this.UpperEdgeChromaPixels = upperEdgeChromaPixels;
            this.SadAdjustment = sadAdjustment;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcSicConfigureIpeLumaChromaINTEL;

        public Node LumaIntraPartitionMask { get; set; }

        public Node IntraNeighbourAvailabilty { get; set; }

        public Node LeftEdgeLumaPixels { get; set; }

        public Node UpperLeftCornerLumaPixel { get; set; }

        public Node UpperEdgeLumaPixels { get; set; }

        public Node UpperRightEdgeLumaPixels { get; set; }

        public Node LeftEdgeChromaPixels { get; set; }

        public Node UpperLeftCornerChromaPixel { get; set; }

        public Node UpperEdgeChromaPixels { get; set; }

        public Node SadAdjustment { get; set; }

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
                yield return CreateInputPin(nameof(LumaIntraPartitionMask), LumaIntraPartitionMask);
                yield return CreateInputPin(nameof(IntraNeighbourAvailabilty), IntraNeighbourAvailabilty);
                yield return CreateInputPin(nameof(LeftEdgeLumaPixels), LeftEdgeLumaPixels);
                yield return CreateInputPin(nameof(UpperLeftCornerLumaPixel), UpperLeftCornerLumaPixel);
                yield return CreateInputPin(nameof(UpperEdgeLumaPixels), UpperEdgeLumaPixels);
                yield return CreateInputPin(nameof(UpperRightEdgeLumaPixels), UpperRightEdgeLumaPixels);
                yield return CreateInputPin(nameof(LeftEdgeChromaPixels), LeftEdgeChromaPixels);
                yield return CreateInputPin(nameof(UpperLeftCornerChromaPixel), UpperLeftCornerChromaPixel);
                yield return CreateInputPin(nameof(UpperEdgeChromaPixels), UpperEdgeChromaPixels);
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

        public SubgroupAvcSicConfigureIpeLumaChromaINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcSicConfigureIpeLumaChromaINTEL)op, treeBuilder);
        }

        public SubgroupAvcSicConfigureIpeLumaChromaINTEL SetUp(Action<SubgroupAvcSicConfigureIpeLumaChromaINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcSicConfigureIpeLumaChromaINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            LumaIntraPartitionMask = treeBuilder.GetNode(op.LumaIntraPartitionMask);
            IntraNeighbourAvailabilty = treeBuilder.GetNode(op.IntraNeighbourAvailabilty);
            LeftEdgeLumaPixels = treeBuilder.GetNode(op.LeftEdgeLumaPixels);
            UpperLeftCornerLumaPixel = treeBuilder.GetNode(op.UpperLeftCornerLumaPixel);
            UpperEdgeLumaPixels = treeBuilder.GetNode(op.UpperEdgeLumaPixels);
            UpperRightEdgeLumaPixels = treeBuilder.GetNode(op.UpperRightEdgeLumaPixels);
            LeftEdgeChromaPixels = treeBuilder.GetNode(op.LeftEdgeChromaPixels);
            UpperLeftCornerChromaPixel = treeBuilder.GetNode(op.UpperLeftCornerChromaPixel);
            UpperEdgeChromaPixels = treeBuilder.GetNode(op.UpperEdgeChromaPixels);
            SadAdjustment = treeBuilder.GetNode(op.SadAdjustment);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcSicConfigureIpeLumaChromaINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcSicConfigureIpeLumaChromaINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcSicConfigureIpeLumaChromaINTEL({ResultType}, {LumaIntraPartitionMask}, {IntraNeighbourAvailabilty}, {LeftEdgeLumaPixels}, {UpperLeftCornerLumaPixel}, {UpperEdgeLumaPixels}, {UpperRightEdgeLumaPixels}, {LeftEdgeChromaPixels}, {UpperLeftCornerChromaPixel}, {UpperEdgeChromaPixels}, {SadAdjustment}, {Payload}, {DebugName})";
        }
    }
}