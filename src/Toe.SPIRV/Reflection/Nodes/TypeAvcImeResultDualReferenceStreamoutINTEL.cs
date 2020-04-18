using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeAvcImeResultDualReferenceStreamoutINTEL : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeAvcImeResultDualReferenceStreamoutINTEL;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.AvcImeResultDualReferenceStreamoutINTEL;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeAvcImeResultDualReferenceStreamoutINTEL)op, treeBuilder);
        }

        partial void SetUp(OpTypeAvcImeResultDualReferenceStreamoutINTEL instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}