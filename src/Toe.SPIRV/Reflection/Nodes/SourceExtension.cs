using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SourceExtension : Node
    {
        public SourceExtension()
        {
        }

        public override Op OpCode => Op.OpSourceExtension;


        public string Extension { get; set; }

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
            SetUp((OpSourceExtension)op, treeBuilder);
        }

        public void SetUp(OpSourceExtension op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Extension = op.Extension;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}