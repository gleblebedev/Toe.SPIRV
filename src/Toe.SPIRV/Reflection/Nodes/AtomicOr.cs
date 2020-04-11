using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicOr : FunctionNode 
    {
        public AtomicOr(OpAtomicOr op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Pointer { get; set; }
        public Node Value { get; set; }
    }
}