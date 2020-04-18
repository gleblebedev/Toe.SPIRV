using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypePointer : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypePointer;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.Pointer;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypePointer)op, treeBuilder);
        }

        partial void SetUp(OpTypePointer instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}