namespace Toe.SPIRV.Reflection
{
    public class SpirvFunctionArgument
    {
        private readonly SpirvTypeBase _type;

        public SpirvFunctionArgument(SpirvTypeBase type)
        {
            _type = type;
        }

        public SpirvTypeBase Type
        {
            get => _type;
        }

        public override string ToString()
        {
            return _type.ToString();
        }
    }
}