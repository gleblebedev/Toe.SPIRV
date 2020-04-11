using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FNegate : FunctionNode 
    {
        public FNegate(OpFNegate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Operand = treeBuilder.GetNode(op.Operand);
        }

        public Node Operand { get; set; }
    }
}