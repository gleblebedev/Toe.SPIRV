using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SampledImage : Node
    {
        public SampledImage()
        {
        }

        public SampledImage(SpirvTypeBase resultType, Node image, Node sampler, string debugName = null)
        {
            this.ResultType = resultType;
            this.Image = image;
            this.Sampler = sampler;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSampledImage;

        public Node Image { get; set; }

        public Node Sampler { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Sampler), Sampler);
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

        public SampledImage WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSampledImage)op, treeBuilder);
        }

        public SampledImage SetUp(Action<SampledImage> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSampledImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Sampler = treeBuilder.GetNode(op.Sampler);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SampledImage object.</summary>
        /// <returns>A string that represents the SampledImage object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SampledImage({ResultType}, {Image}, {Sampler}, {DebugName})";
        }
    }
}