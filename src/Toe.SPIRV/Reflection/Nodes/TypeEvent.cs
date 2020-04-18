using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeEvent : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeEvent;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.Event;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeEvent)op, treeBuilder);
        }

        partial void SetUp(OpTypeEvent instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}