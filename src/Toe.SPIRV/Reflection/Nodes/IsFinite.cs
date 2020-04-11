using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class IsFinite : FunctionNode 
    {
        public IsFinite(OpIsFinite op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            x = treeBuilder.GetNode(op.x);
        }

        public Node x { get; set; }
    }
}