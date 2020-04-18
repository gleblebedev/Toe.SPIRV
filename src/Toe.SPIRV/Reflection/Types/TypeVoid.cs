using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeVoid : SpirvTypeBase
    {
        internal TypeVoid()
        {
        }

        public override uint SizeInBytes => 0;

        public override string ToString()
        {
            return "void";
        }
    }
}