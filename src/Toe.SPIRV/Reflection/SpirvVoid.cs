namespace Toe.SPIRV.Reflection
{
    public class SpirvVoid : SpirvTypeBase
    {
        internal SpirvVoid():base(SpirvType.Void)
        {
        }

        public override uint SizeInBytes => 0;

        public override string ToString()
        {
            return "void";
        }
    }
}