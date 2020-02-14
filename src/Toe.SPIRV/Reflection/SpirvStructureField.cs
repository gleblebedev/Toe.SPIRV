namespace Toe.SPIRV.Reflection
{
    public class SpirvStructureField
    {
        private readonly SpirvTypeBase _type;
        private readonly string _name;
        private uint? _byteOffset;
        private readonly uint? _matrixStride;
        private readonly MatrixOrientation _matrixOrientation;

        public SpirvStructureField(SpirvTypeBase type, string name, uint? byteOffset = null, uint? matrixStride = null, MatrixOrientation matrixOrientation = MatrixOrientation.Undefined)
        {
            _type = type;
            _name = name;
            _byteOffset = byteOffset;
            _matrixStride = matrixStride;
            _matrixOrientation = matrixOrientation;
        }

        public SpirvTypeBase Type => _type;

        public string Name => _name;
        public uint? ByteOffset => _byteOffset;

        public override string ToString()
        {
            return $"{_type} {_name}";
        }
    }
}