using System;

namespace Toe.SPIRV.Reflection
{
    public class SpirvStructureField : IComparable<SpirvStructureField>
    {
        public SpirvStructureField(SpirvTypeBase type, string name, uint? byteOffset = null)
        {
            Type = type;
            Name = name;
            ByteOffset = byteOffset;
        }

        public SpirvTypeBase Type { get; }

        public string Name { get; }

        public uint? ByteOffset { get; internal set; }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }

        public int CompareTo(SpirvStructureField other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Nullable.Compare(ByteOffset, other.ByteOffset);
        }
    }
}