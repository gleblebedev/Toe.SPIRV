using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesMatrix : FunctionNode 
    {
        public MatrixTimesMatrix(OpMatrixTimesMatrix op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            LeftMatrix = treeBuilder.GetNode(op.LeftMatrix);
            RightMatrix = treeBuilder.GetNode(op.RightMatrix);
        }

        public Node LeftMatrix { get; set; }
        public Node RightMatrix { get; set; }
    }
}