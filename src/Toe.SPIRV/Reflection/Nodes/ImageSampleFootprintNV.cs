using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSampleFootprintNV : Node
    {
        public ImageSampleFootprintNV()
        {
        }

        public override Op OpCode => Op.OpImageSampleFootprintNV;


        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
        public Node Granularity { get; set; }
        public Node Coarse { get; set; }
        public Spv.ImageOperands ImageOperands { get; set; }
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
                yield return CreateInputPin(nameof(SampledImage), SampledImage);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(Granularity), Granularity);
                yield return CreateInputPin(nameof(Coarse), Coarse);
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
            base.SetUp(op, treeBuilder);
            SetUp((OpImageSampleFootprintNV)op, treeBuilder);
        }

        public void SetUp(OpImageSampleFootprintNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Granularity = treeBuilder.GetNode(op.Granularity);
            Coarse = treeBuilder.GetNode(op.Coarse);
            ImageOperands = op.ImageOperands;
            SetUpDecorations(op, treeBuilder);
        }
    }
}