using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Transpose : FunctionNode 
    {
        public Transpose(OpTranspose op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Matrix = treeBuilder.GetNode(op.Matrix);
        }

        public Node Matrix { get; set; }
    }
}