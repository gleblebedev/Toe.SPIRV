using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class UDiv : FunctionNode 
    {
        public UDiv(OpUDiv op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Operand1 = treeBuilder.GetNode(op.Operand1);
            Operand2 = treeBuilder.GetNode(op.Operand2);
        }

        public Node Operand1 { get; set; }
        public Node Operand2 { get; set; }
    }
}