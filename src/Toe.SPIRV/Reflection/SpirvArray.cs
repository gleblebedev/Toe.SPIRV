namespace Toe.SPIRV.Reflection
{
    public class SpirvArray : SpirvArrayBase
    {
        private readonly SpirvTypeBase _elementType;
        private readonly uint _length;

        public SpirvArray(SpirvTypeBase elementType, uint length)
        {
            _elementType = elementType;
            _length = length;
        }
        public override uint ArrayStride => _elementType.Alignment;

        public override SpirvTypeBase ElementType => _elementType;

        public override uint Length => _length;
    }
}