using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvEvent : SpirvTypeBase
    {
        public SpirvEvent():base(SpirvTypeCategory.Event)
        {
        }


        public void SetUp(OpTypeEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}