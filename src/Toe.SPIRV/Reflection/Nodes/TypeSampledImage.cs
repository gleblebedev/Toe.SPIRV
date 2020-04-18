using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeSampledImage : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeSampledImage;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.SampledImage;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeSampledImage)op, treeBuilder);
        }

        partial void SetUp(OpTypeSampledImage instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}