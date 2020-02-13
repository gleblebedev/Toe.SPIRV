namespace Toe.SPIRV.Reflection
{
    public class SpirvArray : SpirvType
    {
        private readonly SpirvType _elementType;
        private readonly uint _length;

        public SpirvArray(SpirvType elementType, uint length)
        {
            _elementType = elementType;
            _length = length;
        }

        public override string ToString()
        {
            return $"{_elementType}[{_length}]";
        }
    }
}