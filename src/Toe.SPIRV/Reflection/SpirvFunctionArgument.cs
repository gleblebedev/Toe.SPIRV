namespace Toe.SPIRV.Reflection
{
    public class SpirvFunctionArgument
    {
        private readonly SpirvTypeBase _type;

        public SpirvFunctionArgument(SpirvTypeBase type)
        {
            _type = type;
        }
    }
}