using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvVoid : SpirvTypeBase
    {
        internal SpirvVoid() : base(SpirvTypeCategory.Void)
        {
        }

        public override uint SizeInBytes => 0;

        public override string ToString()
        {
            return "void";
        }
    }
}