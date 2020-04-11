using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CommitReadPipe : SequentialOperationNode 
    {
        public CommitReadPipe(OpCommitReadPipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pipe = treeBuilder.GetNode(op.Pipe);
            ReserveId = treeBuilder.GetNode(op.ReserveId);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }

        public Node Pipe { get; set; }
        public Node ReserveId { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
    }
}