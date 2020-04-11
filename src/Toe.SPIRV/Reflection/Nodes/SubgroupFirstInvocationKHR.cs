using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupFirstInvocationKHR : FunctionNode 
    {
        public SubgroupFirstInvocationKHR(OpSubgroupFirstInvocationKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Value { get; set; }
    }
}