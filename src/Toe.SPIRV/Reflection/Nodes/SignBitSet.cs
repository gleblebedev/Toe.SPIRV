using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SignBitSet : FunctionNode 
    {
        public SignBitSet(OpSignBitSet op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            x = treeBuilder.GetNode(op.x);
        }

        public Node x { get; set; }
    }
}