using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvSampler : SpirvTypeBase
    {
        public SpirvSampler(): base(SpirvTypeCategory.Sampler)
        {
            
        }

        public override Op OpCode => Op.OpTypeSampler;

        public void SetUp(OpTypeSampler op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}