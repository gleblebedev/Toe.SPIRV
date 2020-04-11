using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CopyMemorySized : SequentialOperationNode 
    {
        public CopyMemorySized(OpCopyMemorySized op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Source = treeBuilder.GetNode(op.Source);
            Size = treeBuilder.GetNode(op.Size);
        }

        public Node Target { get; set; }
        public Node Source { get; set; }
        public Node Size { get; set; }
    }
}