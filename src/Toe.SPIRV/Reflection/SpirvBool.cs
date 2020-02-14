namespace Toe.SPIRV.Reflection
{
    public class SpirvBool : SpirvTypeBase
    {
        internal SpirvBool():base(SpirvType.Bool)
        {
        }
        public override string ToString()
        {
            return "bool";
        }

    }
}