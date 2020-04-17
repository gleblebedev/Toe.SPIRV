using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SourceContinued : Node
    {
        public SourceContinued()
        {
        }

        public override Op OpCode => Op.OpSourceContinued;


        public string ContinuedSource { get; set; }

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
            SetUp((OpSourceContinued)op, treeBuilder);
        }

        public void SetUp(OpSourceContinued op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ContinuedSource = op.ContinuedSource;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}