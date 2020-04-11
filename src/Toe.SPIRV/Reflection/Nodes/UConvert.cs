using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class UConvert : FunctionNode 
    {
        public UConvert(OpUConvert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            UnsignedValue = treeBuilder.GetNode(op.UnsignedValue);
        }

        public Node UnsignedValue { get; set; }
    }
}