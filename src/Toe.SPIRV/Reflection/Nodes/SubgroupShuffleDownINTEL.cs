using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleDownINTEL : FunctionNode 
    {
        public SubgroupShuffleDownINTEL(OpSubgroupShuffleDownINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Current = treeBuilder.GetNode(op.Current);
            Next = treeBuilder.GetNode(op.Next);
            Delta = treeBuilder.GetNode(op.Delta);
        }

        public Node Current { get; set; }
        public Node Next { get; set; }
        public Node Delta { get; set; }
    }
}