using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SpecConstantComposite : FunctionNode 
    {
        public SpecConstantComposite(OpSpecConstantComposite op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Constituents = treeBuilder.GetNodes(op.Constituents);
        }

        public IList<Node> Constituents { get; set; }
    }
}