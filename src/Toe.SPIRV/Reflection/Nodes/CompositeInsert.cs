using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CompositeInsert : FunctionNode 
    {
        public CompositeInsert(OpCompositeInsert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Object = treeBuilder.GetNode(op.Object);
            Composite = treeBuilder.GetNode(op.Composite);
        }

        public Node Object { get; set; }
        public Node Composite { get; set; }
    }
}