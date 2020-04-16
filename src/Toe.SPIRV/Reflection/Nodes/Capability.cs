using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Capability : Node
    {
        public Capability()
        {
        }

        public override Op OpCode => Op.OpCapability;


        public Spv.Capability Value { get; set; }

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
            SetUp((OpCapability)op, treeBuilder);
        }

        public void SetUp(OpCapability op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Value = op.Value;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}