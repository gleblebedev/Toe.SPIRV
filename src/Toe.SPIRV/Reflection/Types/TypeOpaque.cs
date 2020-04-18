using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeOpaque : SpirvTypeBase
    {
        public TypeOpaque()
        {
        }

        public string Thenameoftheopaquetype { get; set; }

        partial void SetUp(OpTypeOpaque op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Thenameoftheopaquetype = op.Thenameoftheopaquetype;
        }
    }
}