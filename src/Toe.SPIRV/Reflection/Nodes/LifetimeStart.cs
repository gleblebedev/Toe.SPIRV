using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LifetimeStart : ExecutableNode 
    {
        public LifetimeStart()
        {
        }

        public Node Pointer { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
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
            SetUp((OpLifetimeStart)op, treeBuilder);
        }

        public void SetUp(OpLifetimeStart op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
        }
    }
}