using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Image : Node
    {
        public Image()
        {
        }

        public Image(SpirvTypeBase resultType, Node sampledImage, string debugName = null)
        {
            this.ResultType = resultType;
            this.SampledImage = sampledImage;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpImage;

        public Node SampledImage { get; set; }

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

        public Image WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpImage)op, treeBuilder);
        }

        public Image SetUp(Action<Image> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Image object.</summary>
        /// <returns>A string that represents the Image object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Image({ResultType}, {SampledImage}, {DebugName})";
        }
    }
}