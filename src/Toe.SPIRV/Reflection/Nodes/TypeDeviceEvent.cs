using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeDeviceEvent : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeDeviceEvent;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.DeviceEvent;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeDeviceEvent)op, treeBuilder);
        }

        partial void SetUp(OpTypeDeviceEvent instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}