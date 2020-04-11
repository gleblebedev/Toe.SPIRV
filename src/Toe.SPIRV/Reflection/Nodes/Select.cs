using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Select : FunctionNode 
    {
        public Select(OpSelect op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Condition = treeBuilder.GetNode(op.Condition);
            Object1 = treeBuilder.GetNode(op.Object1);
            Object2 = treeBuilder.GetNode(op.Object2);
        }

        public Node Condition { get; set; }
        public Node Object1 { get; set; }
        public Node Object2 { get; set; }
    }
}