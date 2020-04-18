using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeAvcImeSingleReferenceStreaminINTEL : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeAvcImeSingleReferenceStreaminINTEL;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.AvcImeSingleReferenceStreaminINTEL;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeAvcImeSingleReferenceStreaminINTEL)op, treeBuilder);
        }

        partial void SetUp(OpTypeAvcImeSingleReferenceStreaminINTEL instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}