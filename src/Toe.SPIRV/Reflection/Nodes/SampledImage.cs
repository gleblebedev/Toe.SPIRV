using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SampledImage : FunctionNode 
    {
        public SampledImage()
        {
        }

        public Node Image { get; set; }
        public Node Sampler { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Sampler), Sampler);
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
            SetUp((OpSampledImage)op, treeBuilder);
        }

        public void SetUp(OpSampledImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Sampler = treeBuilder.GetNode(op.Sampler);
        }
    }
}