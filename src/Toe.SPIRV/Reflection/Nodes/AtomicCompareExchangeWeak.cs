using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicCompareExchangeWeak : FunctionNode 
    {
        public AtomicCompareExchangeWeak(OpAtomicCompareExchangeWeak op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            Value = treeBuilder.GetNode(op.Value);
            Comparator = treeBuilder.GetNode(op.Comparator);
        }

        public Node Pointer { get; set; }
        public Node Value { get; set; }
        public Node Comparator { get; set; }
    }
}