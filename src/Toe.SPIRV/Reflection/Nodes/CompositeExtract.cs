using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CompositeExtract : FunctionNode 
    {
        public CompositeExtract(OpCompositeExtract op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Composite = treeBuilder.GetNode(op.Composite);
        }

        public Node Composite { get; set; }
    }
}