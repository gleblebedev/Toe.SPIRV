using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvBool : SpirvTypeBase
    {
        internal SpirvBool() : base(SpirvTypeCategory.Bool)
        {
        }


        public override string ToString()
        {
            return "bool";
        }
    }
}