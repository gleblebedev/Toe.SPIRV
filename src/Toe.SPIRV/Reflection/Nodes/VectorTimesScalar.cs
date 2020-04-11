using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorTimesScalar : FunctionNode 
    {
        public VectorTimesScalar(OpVectorTimesScalar op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Scalar = treeBuilder.GetNode(op.Scalar);
        }

        public Node Vector { get; set; }
        public Node Scalar { get; set; }
    }
}