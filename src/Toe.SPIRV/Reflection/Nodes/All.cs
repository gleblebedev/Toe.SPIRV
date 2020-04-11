using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class All : FunctionNode 
    {
        public All(OpAll op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
        }

        public Node Vector { get; set; }
    }
}