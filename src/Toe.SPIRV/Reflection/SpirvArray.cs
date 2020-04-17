using System;

namespace Toe.SPIRV.Reflection
{
    public abstract partial class SpirvArray : SpirvTypeBase, IEquatable<SpirvArray>
    {
        public SpirvArray() : base(SpirvTypeCategory.Array)
        {
        }

        public abstract uint ArrayStride { get; }

        public abstract uint Length { get; }

        public abstract SpirvTypeBase ElementType { get; }

        public override uint SizeInBytes => Alignment * Length;

        public override uint Alignment => SpirvUtils.RoundUp(ElementType.Alignment, 16);

        public static bool operator ==(SpirvArray left, SpirvArray right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpirvArray left, SpirvArray right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is SpirvArray other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = ElementType.GetHashCode();
            hashCode = (hashCode * 397) ^ Length.GetHashCode();
            hashCode = (hashCode * 397) ^ ArrayStride.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{ElementType}[{Length}]";
        }

        public bool Equals(SpirvArray other)
        {
            return ElementType == other.ElementType
                   && Length == other.Length
                   && ArrayStride == other.ArrayStride
                   && Alignment == other.Alignment;
        }
    }
}