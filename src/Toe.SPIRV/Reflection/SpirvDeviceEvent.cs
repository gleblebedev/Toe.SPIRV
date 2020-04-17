using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvDeviceEvent : SpirvTypeBase
    {
        public SpirvDeviceEvent() : base(SpirvTypeCategory.DeviceEvent)
        {
        }

        public void SetUp(OpTypeEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}