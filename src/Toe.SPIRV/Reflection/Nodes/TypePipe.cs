using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypePipe : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypePipe;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.Pipe;

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypePipe)op, treeBuilder);
        }

        partial void SetUp(OpTypePipe instruction, SpirvInstructionTreeBuilder treeBuilder);
    }
}