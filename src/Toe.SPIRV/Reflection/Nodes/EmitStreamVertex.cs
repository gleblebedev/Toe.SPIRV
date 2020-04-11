using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EmitStreamVertex : SequentialOperationNode 
    {
        public EmitStreamVertex(OpEmitStreamVertex op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Stream = treeBuilder.GetNode(op.Stream);
        }

        public Node Stream { get; set; }
    }
}