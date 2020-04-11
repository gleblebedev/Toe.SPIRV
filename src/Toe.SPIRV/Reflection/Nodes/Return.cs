using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Return : SequentialOperationNode 
    {
        public Return(OpReturn op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

    }
}