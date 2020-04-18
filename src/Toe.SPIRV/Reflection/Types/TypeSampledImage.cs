using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeSampledImage : SpirvTypeBase
    {
        public TypeSampledImage()
        {

        }

        public Node ImageType { get; set; }
       
        partial void SetUp(OpTypeSampledImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ImageType = treeBuilder.GetNode(op.ImageType);
        }
    }
}