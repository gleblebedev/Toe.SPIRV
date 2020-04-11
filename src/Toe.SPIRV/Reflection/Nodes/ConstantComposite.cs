using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConstantComposite : FunctionNode 
    {
        public ConstantComposite(OpConstantComposite op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Constituents = treeBuilder.GetNodes(op.Constituents);
        }

        public IList<Node> Constituents { get; set; }
    }
}