using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class PtrCastToGeneric : FunctionNode 
    {
        public PtrCastToGeneric(OpPtrCastToGeneric op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
        }

        public Node Pointer { get; set; }
    }
}