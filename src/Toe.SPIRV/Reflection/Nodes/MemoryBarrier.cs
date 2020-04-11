using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemoryBarrier : SequentialOperationNode 
    {
        public MemoryBarrier(OpMemoryBarrier op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

    }
}