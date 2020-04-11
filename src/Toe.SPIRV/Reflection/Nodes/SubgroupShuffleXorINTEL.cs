using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleXorINTEL : FunctionNode 
    {
        public SubgroupShuffleXorINTEL(OpSubgroupShuffleXorINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Data = treeBuilder.GetNode(op.Data);
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Data { get; set; }
        public Node Value { get; set; }
    }
}