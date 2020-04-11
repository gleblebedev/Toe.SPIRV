using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReturnValue : SequentialOperationNode 
    {
        public ReturnValue(OpReturnValue op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Value { get; set; }
    }
}