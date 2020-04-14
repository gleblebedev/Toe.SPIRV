using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageDrefGather : FunctionNode 
    {
        public ImageDrefGather()
        {
        }

        public Node SampledImage { get; set; }
        public Node Coordinate { get; set; }
        public Node D_ref { get; set; }
        public IList<Node> Operands { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SampledImage), SampledImage);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(D_ref), D_ref);
                for (var index = 0; index < Operands.Count; index++)
                {
                    yield return CreateInputPin(nameof(Operands) + index, Operands[index]);
                }
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
            SetUp((OpImageDrefGather)op, treeBuilder);
        }

        public void SetUp(OpImageDrefGather op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SampledImage = treeBuilder.GetNode(op.SampledImage);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            D_ref = treeBuilder.GetNode(op.D_ref);
            Operands = treeBuilder.GetNodes(op.Operands);
        }
    }
}