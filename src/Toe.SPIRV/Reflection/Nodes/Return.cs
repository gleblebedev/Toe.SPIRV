using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Return : ExecutableNode
    {
        public Return()
        {
        }

        public override Op OpCode => Op.OpReturn;



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
            SetUp((OpReturn)op, treeBuilder);
        }

        public void SetUp(OpReturn op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}