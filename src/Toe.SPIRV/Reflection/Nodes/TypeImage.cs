using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeImage : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeImage;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.Image;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeImage)op, treeBuilder);
        }

        partial void SetUp(OpTypeImage instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}