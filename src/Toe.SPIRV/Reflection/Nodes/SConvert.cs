using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SConvert : FunctionNode 
    {
        public SConvert(OpSConvert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SignedValue = treeBuilder.GetNode(op.SignedValue);
        }

        public Node SignedValue { get; set; }
    }
}