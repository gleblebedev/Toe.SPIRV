using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LessOrGreater : FunctionNode 
    {
        public LessOrGreater(OpLessOrGreater op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            x = treeBuilder.GetNode(op.x);
            y = treeBuilder.GetNode(op.y);
        }

        public Node x { get; set; }
        public Node y { get; set; }
    }
}