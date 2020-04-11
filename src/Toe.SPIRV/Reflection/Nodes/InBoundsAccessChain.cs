using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class InBoundsAccessChain : FunctionNode 
    {
        public InBoundsAccessChain(OpInBoundsAccessChain op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Indexes = treeBuilder.GetNodes(op.Indexes);
        }

        public Node Base { get; set; }
        public IList<Node> Indexes { get; set; }
    }
}