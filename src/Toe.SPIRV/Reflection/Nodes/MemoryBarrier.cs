using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemoryBarrier : ExecutableNode 
    {
        public MemoryBarrier()
        {
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
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
            SetUp((OpMemoryBarrier)op, treeBuilder);
        }

        public void SetUp(OpMemoryBarrier op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}