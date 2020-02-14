namespace Toe.SPIRV.Reflection
{
    public class SpirvArray : SpirvTypeBase
    {
        private readonly SpirvTypeBase _elementType;
        private readonly uint _length;

        public SpirvArray(SpirvTypeBase elementType, uint length):base(SpirvType.CustomArray)
        {
            _elementType = elementType;
            _length = length;
        }

        public override uint SizeInBytes => _elementType.SizeInBytes * _length;

        public override string ToString()
        {
            return $"{_elementType}[{_length}]";
        }
    }
}