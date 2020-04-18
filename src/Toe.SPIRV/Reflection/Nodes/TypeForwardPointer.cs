using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeForwardPointer : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeForwardPointer;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.ForwardPointer;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeForwardPointer)op, treeBuilder);
        }

        partial void SetUp(OpTypeForwardPointer instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}