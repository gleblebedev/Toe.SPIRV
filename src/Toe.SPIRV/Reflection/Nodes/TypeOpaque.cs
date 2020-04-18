using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeOpaque : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeOpaque;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.Opaque;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeOpaque)op, treeBuilder);
        }

        partial void SetUp(OpTypeOpaque instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}