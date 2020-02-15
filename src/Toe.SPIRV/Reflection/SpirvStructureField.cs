namespace Toe.SPIRV.Reflection
{
    public class SpirvStructureField
    {
        private readonly SpirvTypeBase _type;
        private readonly string _name;
        private uint? _byteOffset;

        public SpirvStructureField(SpirvTypeBase type, string name, uint? byteOffset = null)
        {
            _type = type;
            _name = name;
            _byteOffset = byteOffset;
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