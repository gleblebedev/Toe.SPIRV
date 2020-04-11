using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class QuantizeToF16 : FunctionNode 
    {
        public QuantizeToF16(OpQuantizeToF16 op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Value = treeBuilder.GetNode(op.Value);
        }

        public Node Value { get; set; }
    }
}