using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class IsValidReserveId : FunctionNode 
    {
        public IsValidReserveId(OpIsValidReserveId op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            ReserveId = treeBuilder.GetNode(op.ReserveId);
        }

        public Node ReserveId { get; set; }
    }
}