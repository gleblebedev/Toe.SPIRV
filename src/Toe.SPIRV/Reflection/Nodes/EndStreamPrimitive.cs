using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EndStreamPrimitive : ExecutableNode 
    {
        public EndStreamPrimitive()
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
            SetUp((OpEndStreamPrimitive)op, treeBuilder);
        }

        public void SetUp(OpEndStreamPrimitive op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Stream = treeBuilder.GetNode(op.Stream);
        }
    }
}