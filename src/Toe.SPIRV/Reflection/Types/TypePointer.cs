using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypePointer : SpirvTypeBase
    {
        public TypePointer()
        {
            
        }

        public override string ToString()
        {
            if (DebugName != null)
                return DebugName;
            if (Type != null)
                return $"{Type}*";
            return base.ToString();
        }
    }
}