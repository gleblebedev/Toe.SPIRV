using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Unreachable : ExecutableNode
    {
        public Unreachable()
        {
        }

        public override Op OpCode => Op.OpUnreachable;



        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> EnterPins
        {
            get
            {
                yield return new NodePin(this, "", null);
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpUnreachable)op, treeBuilder);
        }

        public void SetUp(OpUnreachable op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}