using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class DecorateId : SequentialOperationNode 
    {
        public DecorateId(OpDecorateId op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
        }

        public Node Target { get; set; }
    }
}