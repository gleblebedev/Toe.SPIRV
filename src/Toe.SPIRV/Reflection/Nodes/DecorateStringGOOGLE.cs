using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class DecorateStringGOOGLE : SequentialOperationNode 
    {
        public DecorateStringGOOGLE(OpDecorateStringGOOGLE op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
        }

        public Node Target { get; set; }
    }
}