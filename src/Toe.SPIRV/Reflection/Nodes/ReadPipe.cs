using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReadPipe : FunctionNode 
    {
        public ReadPipe(OpReadPipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            Pointer = treeBuilder.GetNode(op.Pointer);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }

        public Node Pipe { get; set; }
        public Node Pointer { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
    }
}