using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAnyKHR : FunctionNode 
    {
        public SubgroupAnyKHR(OpSubgroupAnyKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Predicate = treeBuilder.GetNode(op.Predicate);
        }

        public Node Predicate { get; set; }
    }
}