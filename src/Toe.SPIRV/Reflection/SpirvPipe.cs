using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvPipe : SpirvTypeBase
    {
        public SpirvPipe() : base(SpirvTypeCategory.Pipe)
        {
        }

        public Spv.AccessQualifier Qualifier { get; set; }

        public void SetUp(OpTypePipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Qualifier = op.Qualifier;
        }
    }
}