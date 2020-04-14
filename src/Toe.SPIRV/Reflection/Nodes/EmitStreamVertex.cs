using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EmitStreamVertex : ExecutableNode 
    {
        public EmitStreamVertex()
        {
        }

        public Node Stream { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Stream), Stream);
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
            SetUp((OpEmitStreamVertex)op, treeBuilder);
        }

        public void SetUp(OpEmitStreamVertex op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Stream = treeBuilder.GetNode(op.Stream);
        }
    }
}