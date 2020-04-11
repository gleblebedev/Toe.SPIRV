using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class IsValidEvent : FunctionNode 
    {
        public IsValidEvent(OpIsValidEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Event = treeBuilder.GetNode(op.Event);
        }

        public Node Event { get; set; }
    }
}