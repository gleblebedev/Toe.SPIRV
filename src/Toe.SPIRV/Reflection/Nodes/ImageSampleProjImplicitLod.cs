using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSampleProjImplicitLod : Node
    {
        public ImageSampleProjImplicitLod()
        {
        }

        public ImageSampleProjImplicitLod(SpirvTypeBase resultType, Node sampledImage, Node coordinate, Spv.ImageOperands imageOperands, string debugName = null)
        {
            this.ResultType = resultType;
            this.SampledImage = sampledImage;
            this.Coordinate = coordinate;
            this.ImageOperands = imageOperands;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpImageSampleProjImplicitLod;

        public Node SampledImage { get; set; }

        public Node Coordinate { get; set; }

        public Spv.ImageOperands ImageOperands { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SampledImage), SampledImage);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
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

        public ImageSampleProjImplicitLod WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpImageSampleProjImplicitLod)op, treeBuilder);
        }

        public ImageSampleProjImplicitLod SetUp(Action<ImageSampleProjImplicitLod> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpImageSampleProjImplicitLod op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            ImageOperands = op.ImageOperands;
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the ImageSampleProjImplicitLod object.</summary>
        /// <returns>A string that represents the ImageSampleProjImplicitLod object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"ImageSampleProjImplicitLod({ResultType}, {SampledImage}, {Coordinate}, {ImageOperands}, {DebugName})";
        }
    }
}