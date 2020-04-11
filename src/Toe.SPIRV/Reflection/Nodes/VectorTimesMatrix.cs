using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorTimesMatrix : FunctionNode 
    {
        public VectorTimesMatrix(OpVectorTimesMatrix op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Matrix = treeBuilder.GetNode(op.Matrix);
        }

        public Node Vector { get; set; }
        public Node Matrix { get; set; }
    }
}