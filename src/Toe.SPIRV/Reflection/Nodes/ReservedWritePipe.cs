using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReservedWritePipe : FunctionNode 
    {
        public ReservedWritePipe(OpReservedWritePipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            ReserveId = treeBuilder.GetNode(op.ReserveId);
            Index = treeBuilder.GetNode(op.Index);
            Pointer = treeBuilder.GetNode(op.Pointer);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }

        public Node Pipe { get; set; }
        public Node ReserveId { get; set; }
        public Node Index { get; set; }
        public Node Pointer { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
    }
}