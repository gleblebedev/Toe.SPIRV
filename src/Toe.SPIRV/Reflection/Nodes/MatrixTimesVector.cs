using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MatrixTimesVector : FunctionNode 
    {
        public MatrixTimesVector(OpMatrixTimesVector op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Matrix = treeBuilder.GetNode(op.Matrix);
            Vector = treeBuilder.GetNode(op.Vector);
        }

        public Node Matrix { get; set; }
        public Node Vector { get; set; }
    }
}