using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LogicalNot : FunctionNode 
    {
        public LogicalNot(OpLogicalNot op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Operand = treeBuilder.GetNode(op.Operand);
        }

        public Node Operand { get; set; }
    }
}