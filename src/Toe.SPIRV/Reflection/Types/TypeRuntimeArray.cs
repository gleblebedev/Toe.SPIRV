using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeRuntimeArray : SpirvTypeBase
    {
        public TypeRuntimeArray()
        {
        }

        public Node ElementType { get; set; }
        

        partial void SetUp(OpTypeRuntimeArray op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ElementType = treeBuilder.GetNode(op.ElementType);
        }
    }
}