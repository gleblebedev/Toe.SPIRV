using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class DPdyFine : FunctionNode 
    {
        public DPdyFine(OpDPdyFine op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            P = treeBuilder.GetNode(op.P);
        }

        public Node P { get; set; }
    }
}