using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Bitcast : FunctionNode 
    {
        public Bitcast(OpBitcast op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Operand = treeBuilder.GetNode(op.Operand);
        }

        public Node Operand { get; set; }
    }
}