using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Load : FunctionNode 
    {
        public Load(OpLoad op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
        }

        public Node Pointer { get; set; }
    }
}