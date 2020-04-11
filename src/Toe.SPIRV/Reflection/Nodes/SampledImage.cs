using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SampledImage : FunctionNode 
    {
        public SampledImage(OpSampledImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Sampler = treeBuilder.GetNode(op.Sampler);
        }

        public Node Image { get; set; }
        public Node Sampler { get; set; }
    }
}