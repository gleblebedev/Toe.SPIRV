using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConvertUToPtr : FunctionNode 
    {
        public ConvertUToPtr(OpConvertUToPtr op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            IntegerValue = treeBuilder.GetNode(op.IntegerValue);
        }

        public Node IntegerValue { get; set; }
    }
}