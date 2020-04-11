using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupReadInvocationKHR : FunctionNode 
    {
        public SubgroupReadInvocationKHR(OpSubgroupReadInvocationKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Value = treeBuilder.GetNode(op.Value);
            Index = treeBuilder.GetNode(op.Index);
        }

        public Node Value { get; set; }
        public Node Index { get; set; }
    }
}