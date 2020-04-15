using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvBool : SpirvTypeBase
    {
        internal SpirvBool() : base(SpirvTypeCategory.Bool)
        {
        }

        public override Op OpCode => Op.OpTypeBool;


        public override string ToString()
        {
            return "bool";
        }
    }
}