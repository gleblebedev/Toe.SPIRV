using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupBlockReadINTEL : FunctionNode 
    {
        public SubgroupBlockReadINTEL(OpSubgroupBlockReadINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Ptr = treeBuilder.GetNode(op.Ptr);
        }

        public Node Ptr { get; set; }
    }
}