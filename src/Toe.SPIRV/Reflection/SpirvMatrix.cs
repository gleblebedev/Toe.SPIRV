namespace Toe.SPIRV.Reflection
{
    public class SpirvMatrix : SpirvTypeBase
    {
        private readonly SpirvVector _columnType;
        private readonly uint _columnCount;
        private readonly uint _columnStride;

        public SpirvMatrix(SpirvVector columnType, uint columnCount) :base(GetType(columnType, columnCount))
        {
            _columnType = columnType;
            _columnCount = columnCount;
            _columnStride = _columnType.SizeInBytes * 4;
        }

        public SpirvVector ColumnType => _columnType;
        public uint ColumnCount => _columnCount;

        public override uint SizeInBytes => _columnStride * _columnCount;
        public static SpirvType GetType(SpirvTypeBase columnType, uint columnCount)
        {
            switch (columnType.Type)
            {
                case SpirvType.Vec2:
                    if (columnCount == 2)
                        return SpirvType.Mat2;
                    break;
                case SpirvType.Vec3:
                    if (columnCount == 3)
                        return SpirvType.Mat3;
                    break;
                case SpirvType.Vec4:
                    if (columnCount == 4)
                        return SpirvType.Mat4;
                    break;
            }

            return SpirvType.CustomMatrix;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case SpirvType.Mat2: return "mat2";
                case SpirvType.Mat3: return "mat3";
                case SpirvType.Mat4: return "mat4";
            }
            return base.ToString();
        }
    }
}