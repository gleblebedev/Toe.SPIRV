using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcBmeInitializeINTEL : Node
    {
        public SubgroupAvcBmeInitializeINTEL()
        {
        }

        public SubgroupAvcBmeInitializeINTEL(SpirvTypeBase resultType, Node srcCoord, Node motionVectors, Node majorShapes, Node minorShapes, Node direction, Node pixelResolution, Node bidirectionalWeight, Node sadAdjustment, string debugName = null)
        {
            this.ResultType = resultType;
            this.SrcCoord = srcCoord;
            this.MotionVectors = motionVectors;
            this.MajorShapes = majorShapes;
            this.MinorShapes = minorShapes;
            this.Direction = direction;
            this.PixelResolution = pixelResolution;
            this.BidirectionalWeight = bidirectionalWeight;
            this.SadAdjustment = sadAdjustment;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcBmeInitializeINTEL;

        public Node SrcCoord { get; set; }

        public Node MotionVectors { get; set; }

        public Node MajorShapes { get; set; }

        public Node MinorShapes { get; set; }

        public Node Direction { get; set; }

        public Node PixelResolution { get; set; }

        public Node BidirectionalWeight { get; set; }

        public Node SadAdjustment { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SrcCoord), SrcCoord);
                yield return CreateInputPin(nameof(MotionVectors), MotionVectors);
                yield return CreateInputPin(nameof(MajorShapes), MajorShapes);
                yield return CreateInputPin(nameof(MinorShapes), MinorShapes);
                yield return CreateInputPin(nameof(Direction), Direction);
                yield return CreateInputPin(nameof(PixelResolution), PixelResolution);
                yield return CreateInputPin(nameof(BidirectionalWeight), BidirectionalWeight);
                yield return CreateInputPin(nameof(SadAdjustment), SadAdjustment);
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

        public SubgroupAvcBmeInitializeINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcBmeInitializeINTEL)op, treeBuilder);
        }

        public SubgroupAvcBmeInitializeINTEL SetUp(Action<SubgroupAvcBmeInitializeINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcBmeInitializeINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcCoord = treeBuilder.GetNode(op.SrcCoord);
            MotionVectors = treeBuilder.GetNode(op.MotionVectors);
            MajorShapes = treeBuilder.GetNode(op.MajorShapes);
            MinorShapes = treeBuilder.GetNode(op.MinorShapes);
            Direction = treeBuilder.GetNode(op.Direction);
            PixelResolution = treeBuilder.GetNode(op.PixelResolution);
            BidirectionalWeight = treeBuilder.GetNode(op.BidirectionalWeight);
            SadAdjustment = treeBuilder.GetNode(op.SadAdjustment);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcBmeInitializeINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcBmeInitializeINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcBmeInitializeINTEL({ResultType}, {SrcCoord}, {MotionVectors}, {MajorShapes}, {MinorShapes}, {Direction}, {PixelResolution}, {BidirectionalWeight}, {SadAdjustment}, {DebugName})";
        }
    }
}