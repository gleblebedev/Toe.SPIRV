using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvOpaque : SpirvTypeBase
    {
        public SpirvOpaque(): base(SpirvTypeCategory.Opaque)
        {
        }

        public string Thenameoftheopaquetype { get; set; }

        public void SetUp(OpTypeOpaque op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Thenameoftheopaquetype = op.Thenameoftheopaquetype;
        }
    }
}