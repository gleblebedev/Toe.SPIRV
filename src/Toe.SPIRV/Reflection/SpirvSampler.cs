using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvSampler : SpirvTypeBase
    {
        public SpirvSampler(): base(SpirvTypeCategory.Sampler)
        {
            
        }

        public void SetUp(OpTypeSampler op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}