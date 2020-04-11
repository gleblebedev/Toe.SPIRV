using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorInsertDynamic : FunctionNode 
    {
        public VectorInsertDynamic(OpVectorInsertDynamic op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Component = treeBuilder.GetNode(op.Component);
            Index = treeBuilder.GetNode(op.Index);
        }

        public Node Vector { get; set; }
        public Node Component { get; set; }
        public Node Index { get; set; }
    }
}