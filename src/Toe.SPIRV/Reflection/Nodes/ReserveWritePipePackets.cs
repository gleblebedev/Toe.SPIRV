using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReserveWritePipePackets : FunctionNode 
    {
        public ReserveWritePipePackets(OpReserveWritePipePackets op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            NumPackets = treeBuilder.GetNode(op.NumPackets);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }

        public Node Pipe { get; set; }
        public Node NumPackets { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
    }
}