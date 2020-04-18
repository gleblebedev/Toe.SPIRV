using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeSampler : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeSampler;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.Sampler;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeSampler)op, treeBuilder);
        }

        partial void SetUp(OpTypeSampler instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}