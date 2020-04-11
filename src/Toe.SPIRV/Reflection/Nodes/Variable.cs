using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Variable : FunctionNode 
    {
        public Variable(OpVariable op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Initializer = treeBuilder.GetNode(op.Initializer);
        }

        public Node Initializer { get; set; }
    }
}