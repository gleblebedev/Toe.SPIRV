using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesScalar : FunctionNode 
    {
        public MatrixTimesScalar(OpMatrixTimesScalar op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Matrix = treeBuilder.GetNode(op.Matrix);
            Scalar = treeBuilder.GetNode(op.Scalar);
        }

        public Node Matrix { get; set; }
        public Node Scalar { get; set; }
    }
}