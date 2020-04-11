using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupBroadcast : FunctionNode 
    {
        public GroupBroadcast(OpGroupBroadcast op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Value = treeBuilder.GetNode(op.Value);
            LocalId = treeBuilder.GetNode(op.LocalId);
        }

        public Node Value { get; set; }
        public Node LocalId { get; set; }
    }
}