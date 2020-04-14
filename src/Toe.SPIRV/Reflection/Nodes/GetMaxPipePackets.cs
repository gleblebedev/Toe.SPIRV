using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GetMaxPipePackets : FunctionNode 
    {
        public GetMaxPipePackets()
        {
        }

        public Node Pipe { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pipe), Pipe);
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
            SetUp((OpGetMaxPipePackets)op, treeBuilder);
        }

        public void SetUp(OpGetMaxPipePackets op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }
    }
}