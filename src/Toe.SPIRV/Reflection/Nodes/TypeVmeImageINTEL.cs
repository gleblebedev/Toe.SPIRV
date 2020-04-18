using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeVmeImageINTEL : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeVmeImageINTEL;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.VmeImageINTEL;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeVmeImageINTEL)op, treeBuilder);
        }

        partial void SetUp(OpTypeVmeImageINTEL instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}