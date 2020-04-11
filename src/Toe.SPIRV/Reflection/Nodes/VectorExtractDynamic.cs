using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorExtractDynamic : FunctionNode 
    {
        public VectorExtractDynamic(OpVectorExtractDynamic op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Index = treeBuilder.GetNode(op.Index);
        }

        public Node Vector { get; set; }
        public Node Index { get; set; }
    }
}