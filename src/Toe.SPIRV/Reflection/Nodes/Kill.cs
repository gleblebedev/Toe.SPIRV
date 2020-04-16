using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Kill : ExecutableNode
    {
        public Kill()
        {
        }

        public override Op OpCode => Op.OpKill;



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
            SetUp((OpKill)op, treeBuilder);
        }

        public void SetUp(OpKill op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}