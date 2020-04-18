using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeForwardPointer : SpirvTypeBase
    {
        public TypeForwardPointer()
        {
        }


        public SpirvTypeBase PointerType { get; set; }

        public Spv.StorageClass StorageClass { get; set; }
   

        partial void SetUp(OpTypeForwardPointer op, SpirvInstructionTreeBuilder treeBuilder)
        {
            PointerType = treeBuilder.ResolveType(op.PointerType);
            StorageClass = op.StorageClass;
        }
    }
}