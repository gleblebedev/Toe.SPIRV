using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvReserveId : SpirvTypeBase
    {
        public SpirvReserveId():base(SpirvTypeCategory.ReserveId)
        {
        }

        public override Op OpCode => Op.OpTypeReserveId;


        public void SetUp(OpTypeReserveId op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}