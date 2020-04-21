using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageQuerySizeLod : Node
    {
        public ImageQuerySizeLod()
        {
        }

        public ImageQuerySizeLod(SpirvTypeBase resultType, Node image, Node levelofDetail, string debugName = null)
        {
            this.ResultType = resultType;
            this.Image = image;
            this.LevelofDetail = levelofDetail;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpImageQuerySizeLod;

        public Node Image { get; set; }

        public Node LevelofDetail { get; set; }

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
                yield return CreateInputPin(nameof(LevelofDetail), LevelofDetail);
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

        public ImageQuerySizeLod WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpImageQuerySizeLod)op, treeBuilder);
        }

        public ImageQuerySizeLod SetUp(Action<ImageQuerySizeLod> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpImageQuerySizeLod op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            LevelofDetail = treeBuilder.GetNode(op.LevelofDetail);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the ImageQuerySizeLod object.</summary>
        /// <returns>A string that represents the ImageQuerySizeLod object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"ImageQuerySizeLod({ResultType}, {Image}, {LevelofDetail}, {DebugName})";
        }
    }
}