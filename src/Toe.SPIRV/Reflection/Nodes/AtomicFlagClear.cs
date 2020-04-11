using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicFlagClear : SequentialOperationNode 
    {
        public AtomicFlagClear(OpAtomicFlagClear op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
        }

        public Node Pointer { get; set; }
    }
}