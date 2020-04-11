using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ControlBarrier : SequentialOperationNode 
    {
        public ControlBarrier(OpControlBarrier op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

    }
}