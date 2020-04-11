using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CopyMemory : SequentialOperationNode 
    {
        public CopyMemory(OpCopyMemory op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Source = treeBuilder.GetNode(op.Source);
        }

        public Node Target { get; set; }
        public Node Source { get; set; }
    }
}