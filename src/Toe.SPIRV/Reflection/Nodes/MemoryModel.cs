using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemoryModel : Node
    {
        public MemoryModel()
        {
        }

        public override Op OpCode => Op.OpMemoryModel;


        public Spv.AddressingModel AddressingModel { get; set; }
        public Spv.MemoryModel Value { get; set; }

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
            SetUp((OpMemoryModel)op, treeBuilder);
        }

        public void SetUp(OpMemoryModel op, SpirvInstructionTreeBuilder treeBuilder)
        {
            AddressingModel = op.AddressingModel;
            Value = op.Value;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}