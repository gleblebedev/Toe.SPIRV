using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CommitWritePipe : ExecutableNode 
    {
        public CommitWritePipe()
        {
        }

        public Node Pipe { get; set; }
        public Node ReserveId { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pipe), Pipe);
                yield return CreateInputPin(nameof(ReserveId), ReserveId);
                yield return CreateInputPin(nameof(PacketSize), PacketSize);
                yield return CreateInputPin(nameof(PacketAlignment), PacketAlignment);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpCommitWritePipe)op, treeBuilder);
        }

        public void SetUp(OpCommitWritePipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pipe = treeBuilder.GetNode(op.Pipe);
            ReserveId = treeBuilder.GetNode(op.ReserveId);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }
    }
}