using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConvertUToF : FunctionNode 
    {
        public ConvertUToF(OpConvertUToF op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            UnsignedValue = treeBuilder.GetNode(op.UnsignedValue);
        }

        public Node UnsignedValue { get; set; }
    }
}