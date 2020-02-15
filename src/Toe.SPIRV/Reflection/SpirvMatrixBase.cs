using System;

namespace Toe.SPIRV.Reflection
{
    public abstract class SpirvMatrixBase : SpirvTypeBase, IEquatable<SpirvMatrixBase>
    {
        public bool Equals(SpirvMatrixBase other)
        {
            return (ColumnType == other.ColumnType
                    && ColumnCount == other.ColumnCount
                    && ColumnStride == other.ColumnStride
                    && MatrixOrientation == other.MatrixOrientation);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is SpirvMatrixBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = ColumnType.GetHashCode();
            hashCode = (hashCode * 397) ^ ColumnCount.GetHashCode();
            hashCode = (hashCode * 397) ^ ColumnStride.GetHashCode();
            hashCode = (hashCode * 397) ^ MatrixOrientation.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SpirvMatrixBase left, SpirvMatrixBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpirvMatrixBase left, SpirvMatrixBase right)
        {
            return !Equals(left, right);
        }

        public SpirvMatrixBase():base(SpirvTypeCategory.Matrix)
        {
        }

        public abstract SpirvVector ColumnType { get; }

        public override uint Alignment => ColumnType.ComponentType.SizeInBytes * 4;

        public override uint SizeInBytes => ColumnStride * ColumnCount;

        public abstract uint ColumnStride { get; }

        public abstract MatrixOrientation MatrixOrientation { get; }

        public abstract uint ColumnCount { get; }

        public override string ToString()
        {
            var componentCount = ColumnType.ComponentCount;
            if (componentCount == ColumnCount)
                return "mat"+ componentCount;
            else
                return "mat" + ColumnCount + "x" + componentCount;
        }
    }
}