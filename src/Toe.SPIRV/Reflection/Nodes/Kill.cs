using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Kill : SequentialOperationNode 
    {
        public Kill(OpKill op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

    }
}