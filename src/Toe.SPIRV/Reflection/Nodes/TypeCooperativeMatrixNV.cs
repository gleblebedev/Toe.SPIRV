using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeCooperativeMatrixNV : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeCooperativeMatrixNV;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.CooperativeMatrixNV;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeCooperativeMatrixNV)op, treeBuilder);
        }

        partial void SetUp(OpTypeCooperativeMatrixNV instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}