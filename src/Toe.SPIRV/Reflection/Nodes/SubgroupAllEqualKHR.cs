using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAllEqualKHR : FunctionNode 
    {
        public SubgroupAllEqualKHR(OpSubgroupAllEqualKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Predicate = treeBuilder.GetNode(op.Predicate);
        }

        public Node Predicate { get; set; }
    }
}