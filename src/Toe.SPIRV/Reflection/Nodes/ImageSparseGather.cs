using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSparseGather : FunctionNode 
    {
        public ImageSparseGather()
        {
        }

        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
        public Node Component { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SampledImage), SampledImage);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(Component), Component);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpImageSparseGather)op, treeBuilder);
        }

        public void SetUp(OpImageSparseGather op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Component = treeBuilder.GetNode(op.Component);
        }
    }
}