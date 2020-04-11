using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CopyObject : FunctionNode 
    {
        public CopyObject(OpCopyObject op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Operand = treeBuilder.GetNode(op.Operand);
        }

        public Node Operand { get; set; }
    }
}