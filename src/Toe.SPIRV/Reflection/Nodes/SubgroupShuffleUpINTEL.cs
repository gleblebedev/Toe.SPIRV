using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleUpINTEL : FunctionNode 
    {
        public SubgroupShuffleUpINTEL(OpSubgroupShuffleUpINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Previous = treeBuilder.GetNode(op.Previous);
            Current = treeBuilder.GetNode(op.Current);
            Delta = treeBuilder.GetNode(op.Delta);
        }

        public Node Previous { get; set; }
        public Node Current { get; set; }
        public Node Delta { get; set; }
    }
}