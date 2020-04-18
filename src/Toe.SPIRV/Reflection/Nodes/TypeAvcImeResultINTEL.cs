using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeAvcImeResultINTEL : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeAvcImeResultINTEL;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.AvcImeResultINTEL;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeAvcImeResultINTEL)op, treeBuilder);
        }

        partial void SetUp(OpTypeAvcImeResultINTEL instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}