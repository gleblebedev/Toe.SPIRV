using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Nop : Node
    {
        public Nop()
        {
        }

        public override Op OpCode => Op.OpNop;



        public override IEnumerable<NodePin> OutputPins
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
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpNop)op, treeBuilder);
        }

        public void SetUp(OpNop op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}