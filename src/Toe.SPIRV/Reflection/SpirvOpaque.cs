using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvOpaque : Node
    {
        public SpirvOpaque()
        {
        }

        public override Op OpCode => Op.OpTypeOpaque;

        public string Thenameoftheopaquetype { get; set; }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpTypeOpaque)op, treeBuilder);
        }

        public void SetUp(OpTypeOpaque op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Thenameoftheopaquetype = op.Thenameoftheopaquetype;
        }
    }
}