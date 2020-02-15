using System;

namespace Toe.SPIRV.Reflection
{
    public abstract class SpirvArrayBase : SpirvTypeBase, IEquatable<SpirvArrayBase>
    {
        public bool Equals(SpirvArrayBase other)
        {
            return (ElementType == other.ElementType
                    && Length == other.Length
                    && ArrayStride == other.ArrayStride
                    && Alignment == other.Alignment);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is SpirvArrayBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = ElementType.GetHashCode();
            hashCode = (hashCode * 397) ^ Length.GetHashCode();
            hashCode = (hashCode * 397) ^ ArrayStride.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SpirvArrayBase left, SpirvArrayBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpirvArrayBase left, SpirvArrayBase right)
        {
            return !Equals(left, right);
        }

        public SpirvArrayBase():base(SpirvTypeCategory.Array)
        {
            
        }
        public abstract uint ArrayStride { get; }

        public abstract uint Length { get; }

        public abstract SpirvTypeBase ElementType { get; }

        public override uint SizeInBytes => Alignment * Length;

        public override uint Alignment => SpirvUtils.RoundUp(ElementType.Alignment,16);

        public override string ToString()
        {
            return $"{ElementType}[{Length}]";
        }

    }
}