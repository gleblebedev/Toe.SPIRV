using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupAsyncCopy : FunctionNode 
    {
        public GroupAsyncCopy(OpGroupAsyncCopy op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Destination = treeBuilder.GetNode(op.Destination);
            Source = treeBuilder.GetNode(op.Source);
            NumElements = treeBuilder.GetNode(op.NumElements);
            Stride = treeBuilder.GetNode(op.Stride);
            Event = treeBuilder.GetNode(op.Event);
        }

        public Node Destination { get; set; }
        public Node Source { get; set; }
        public Node NumElements { get; set; }
        public Node Stride { get; set; }
        public Node Event { get; set; }
    }
}