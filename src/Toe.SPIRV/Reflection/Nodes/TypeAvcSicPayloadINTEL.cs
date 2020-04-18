using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeAvcSicPayloadINTEL : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeAvcSicPayloadINTEL;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.AvcSicPayloadINTEL;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeAvcSicPayloadINTEL)op, treeBuilder);
        }

        partial void SetUp(OpTypeAvcSicPayloadINTEL instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}