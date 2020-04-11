using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BitReverse : FunctionNode 
    {
        public BitReverse(OpBitReverse op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
        }

        public Node Base { get; set; }
    }
}