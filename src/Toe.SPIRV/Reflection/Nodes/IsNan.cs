using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class IsNan : FunctionNode 
    {
        public IsNan(OpIsNan op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            x = treeBuilder.GetNode(op.x);
        }

        public Node x { get; set; }
    }
}