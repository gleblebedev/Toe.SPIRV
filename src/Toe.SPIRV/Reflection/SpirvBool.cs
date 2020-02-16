namespace Toe.SPIRV.Reflection
{
    public class SpirvBool : SpirvTypeBase
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