using System;

namespace Toe.SPIRV.Reflection
{
    public class SpirvStructureField : IComparable<SpirvStructureField>
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

        public uint? ByteOffset
        {
            get { return _byteOffset; }
            internal set { _byteOffset = value; }
        }
        public int CompareTo(SpirvStructureField other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Nullable.Compare(_byteOffset, other._byteOffset);
        }

        public override string ToString()
        {
            return $"{_type} {_name}";
        }
    }
}