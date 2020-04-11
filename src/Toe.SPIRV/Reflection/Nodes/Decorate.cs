using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Decorate : SequentialOperationNode 
    {
        public Decorate(OpDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
        }

        public Node Target { get; set; }
    }
}