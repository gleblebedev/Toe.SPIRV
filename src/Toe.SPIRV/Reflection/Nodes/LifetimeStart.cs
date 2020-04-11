using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LifetimeStart : SequentialOperationNode 
    {
        public LifetimeStart(OpLifetimeStart op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
        }

        public Node Pointer { get; set; }
    }
}