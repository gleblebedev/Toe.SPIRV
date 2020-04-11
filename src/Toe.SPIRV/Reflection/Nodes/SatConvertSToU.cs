using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SatConvertSToU : FunctionNode 
    {
        public SatConvertSToU(OpSatConvertSToU op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            SignedValue = treeBuilder.GetNode(op.SignedValue);
        }

        public Node SignedValue { get; set; }
    }
}