using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleINTEL : FunctionNode 
    {
        public SubgroupShuffleINTEL(OpSubgroupShuffleINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Data = treeBuilder.GetNode(op.Data);
            InvocationId = treeBuilder.GetNode(op.InvocationId);
        }

        public Node Data { get; set; }
        public Node InvocationId { get; set; }
    }
}