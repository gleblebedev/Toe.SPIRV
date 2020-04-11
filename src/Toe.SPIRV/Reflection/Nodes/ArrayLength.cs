using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ArrayLength : FunctionNode 
    {
        public ArrayLength(OpArrayLength op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Structure = treeBuilder.GetNode(op.Structure);
        }

        public Node Structure { get; set; }
    }
}