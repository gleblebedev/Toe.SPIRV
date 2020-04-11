using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EndPrimitive : SequentialOperationNode 
    {
        public EndPrimitive(OpEndPrimitive op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

    }
}