namespace Toe.SPIRV.Reflection
{
    public class SpirvArray : SpirvTypeBase
    {
        private readonly SpirvTypeBase _elementType;
        private readonly uint _length;
        private readonly uint? _arrayStride;

        public SpirvArray(SpirvTypeBase elementType, uint length, uint? arrayStride):base(SpirvType.CustomArray)
        {
            _elementType = elementType;
            _length = length;
            _arrayStride = arrayStride;
        }
        public uint ArrayStride => _arrayStride ?? _elementType.SizeInBytes;

        public override uint SizeInBytes => (_arrayStride ??_elementType.SizeInBytes) * _length;

        public override string ToString()
        {
            return $"{_elementType}[{_length}]";
        }
    }
}