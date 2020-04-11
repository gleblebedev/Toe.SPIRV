using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupFMin : FunctionNode 
    {
        public GroupFMin(OpGroupFMin op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            X = treeBuilder.GetNode(op.X);
        }

        public Node X { get; set; }
    }
}