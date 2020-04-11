using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicStore : SequentialOperationNode 
    {
        public AtomicStore(OpAtomicStore op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Pointer { get; set; }
        public Node Value { get; set; }
    }
}