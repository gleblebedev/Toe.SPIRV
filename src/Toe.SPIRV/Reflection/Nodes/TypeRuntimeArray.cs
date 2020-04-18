using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeRuntimeArray : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeRuntimeArray;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.RuntimeArray;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeRuntimeArray)op, treeBuilder);
        }

        partial void SetUp(OpTypeRuntimeArray instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}