using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ExtInstImport : Node
    {
        public ExtInstImport()
        {
        }

        public override Op OpCode => Op.OpExtInstImport;


        public string Name { get; set; }

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
            SetUp((OpExtInstImport)op, treeBuilder);
        }

        public void SetUp(OpExtInstImport op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Name = op.Name;
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}