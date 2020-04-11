using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AccessChain : FunctionNode 
    {
        public AccessChain(OpAccessChain op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Indexes = treeBuilder.GetNodes(op.Indexes);
        }

        public Node Base { get; set; }
        public IList<Node> Indexes { get; set; }
    }
}