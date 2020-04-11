using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class DPdxFine : FunctionNode 
    {
        public DPdxFine(OpDPdxFine op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            P = treeBuilder.GetNode(op.P);
        }

        public Node P { get; set; }
    }
}