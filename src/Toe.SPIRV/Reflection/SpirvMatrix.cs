using System;

namespace Toe.SPIRV.Reflection
{
    public abstract partial class SpirvMatrix : SpirvTypeBase, IEquatable<SpirvMatrix>
    {
        public SpirvMatrix() : base(SpirvTypeCategory.Matrix)
        {
        }

        public abstract SpirvVector ColumnType { get; }

        public abstract uint ColumnStride { get; }

        public abstract MatrixOrientation MatrixOrientation { get; }

        public abstract uint ColumnCount { get; }

        public override uint Alignment => ColumnType.ComponentType.SizeInBytes * 4;

        public override uint SizeInBytes => ColumnStride * ColumnCount;

        public static bool operator ==(SpirvMatrix left, SpirvMatrix right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpirvMatrix left, SpirvMatrix right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is SpirvMatrix other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = ColumnType.GetHashCode();
            hashCode = (hashCode * 397) ^ ColumnCount.GetHashCode();
            hashCode = (hashCode * 397) ^ ColumnStride.GetHashCode();
            hashCode = (hashCode * 397) ^ MatrixOrientation.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var componentCount = ColumnType.ComponentCount;
            if (componentCount == ColumnCount)
                return "mat" + componentCount;
            return "mat" + ColumnCount + "x" + componentCount;
        }

        public bool Equals(SpirvMatrix other)
        {
            return ColumnType == other.ColumnType
                   && ColumnCount == other.ColumnCount
                   && ColumnStride == other.ColumnStride
                   && MatrixOrientation == other.MatrixOrientation;
        }
    }
}