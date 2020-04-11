using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorShuffle : FunctionNode 
    {
        public VectorShuffle(OpVectorShuffle op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Vector1 = treeBuilder.GetNode(op.Vector1);
            Vector2 = treeBuilder.GetNode(op.Vector2);
        }

        public Node Vector1 { get; set; }
        public Node Vector2 { get; set; }
    }
}