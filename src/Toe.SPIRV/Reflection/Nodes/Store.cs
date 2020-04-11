using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Store : SequentialOperationNode 
    {
        public Store(OpStore op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
            Object = treeBuilder.GetNode(op.Object);
        }

        public Node Pointer { get; set; }
        public Node Object { get; set; }
    }
}