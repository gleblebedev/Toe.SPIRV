using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class WritePipe : FunctionNode 
    {
        public WritePipe()
        {
        }

        public Node Pipe { get; set; }
        public Node Pointer { get; set; }
        public Node PacketSize { get; set; }
        public Node PacketAlignment { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pipe), Pipe);
                yield return CreateInputPin(nameof(Pointer), Pointer);
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
            SetUp((OpWritePipe)op, treeBuilder);
        }

        public void SetUp(OpWritePipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            Pointer = treeBuilder.GetNode(op.Pointer);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
        }
    }
}