using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupReserveWritePipePackets : FunctionNode 
    {
        public GroupReserveWritePipePackets()
        {
        }

        public Node Pipe { get; set; }
        public Node NumPackets { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pipe), Pipe);
                yield return CreateInputPin(nameof(NumPackets), NumPackets);
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
            SetUp((OpGroupReserveWritePipePackets)op, treeBuilder);
        }

        public void SetUp(OpGroupReserveWritePipePackets op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            NumPackets = treeBuilder.GetNode(op.NumPackets);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }
    }
}