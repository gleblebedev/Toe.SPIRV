using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvForwardPointer : SpirvTypeBase
    {
        public SpirvForwardPointer() : base(SpirvTypeCategory.ForwardPointer)
        {
        }


        public SpirvTypeBase PointerType { get; set; }

        public Spv.StorageClass StorageClass { get; set; }
   

        public void SetUp(OpTypeForwardPointer op, SpirvInstructionTreeBuilder treeBuilder)
        {
            PointerType = treeBuilder.ResolveType(op.PointerType);
            StorageClass = op.StorageClass;
        }
    }
}