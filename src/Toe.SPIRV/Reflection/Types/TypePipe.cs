using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypePipe : SpirvTypeBase
    {
        public TypePipe()
        {
        }

        public Spv.AccessQualifier Qualifier { get; set; }

        partial void SetUp(OpTypePipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Qualifier = op.Qualifier;
        }
    }
}