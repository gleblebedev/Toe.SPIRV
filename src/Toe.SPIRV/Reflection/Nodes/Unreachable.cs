using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Unreachable : SequentialOperationNode 
    {
        public Unreachable(OpUnreachable op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

    }
}