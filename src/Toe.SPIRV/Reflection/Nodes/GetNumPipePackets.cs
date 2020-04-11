using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GetNumPipePackets : FunctionNode 
    {
        public GetNumPipePackets(OpGetNumPipePackets op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }

        public Node Pipe { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
    }
}