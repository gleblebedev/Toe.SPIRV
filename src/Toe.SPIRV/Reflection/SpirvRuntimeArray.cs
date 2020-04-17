using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvRuntimeArray : SpirvTypeBase
    {
        public SpirvRuntimeArray(): base(SpirvTypeCategory.Array)
        {
        }

        public Node ElementType { get; set; }
        

        public void SetUp(OpTypeRuntimeArray op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ElementType = treeBuilder.GetNode(op.ElementType);
        }
    }
}