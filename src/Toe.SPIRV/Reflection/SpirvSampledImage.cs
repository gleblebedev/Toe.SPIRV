using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvSampledImage : SpirvTypeBase
    {
        public SpirvSampledImage() : base(SpirvTypeCategory.SampledImage)
        {

        }

        public override Op OpCode => Op.OpTypeSampledImage;


        public Node ImageType { get; set; }
       
        public void SetUp(OpTypeSampledImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ImageType = treeBuilder.GetNode(op.ImageType);
        }
    }
}