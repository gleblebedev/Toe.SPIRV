using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvQueue : SpirvTypeBase
    {
        public SpirvQueue():base(SpirvTypeCategory.Queue)
        {
        }
        public override Op OpCode => Op.OpTypeQueue;

        public void SetUp(OpTypeQueue op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}