using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BitFieldSExtract : FunctionNode 
    {
        public BitFieldSExtract(OpBitFieldSExtract op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Offset = treeBuilder.GetNode(op.Offset);
            Count = treeBuilder.GetNode(op.Count);
        }

        public Node Base { get; set; }
        public Node Offset { get; set; }
        public Node Count { get; set; }
    }
}