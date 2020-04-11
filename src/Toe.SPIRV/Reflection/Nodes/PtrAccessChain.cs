using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class PtrAccessChain : FunctionNode 
    {
        public PtrAccessChain(OpPtrAccessChain op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Element = treeBuilder.GetNode(op.Element);
            Indexes = treeBuilder.GetNodes(op.Indexes);
        }

        public Node Base { get; set; }
        public Node Element { get; set; }
        public IList<Node> Indexes { get; set; }
    }
}