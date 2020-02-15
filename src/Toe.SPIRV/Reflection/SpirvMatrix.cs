using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvMatrix : SpirvMatrixBase
    {
        private readonly SpirvVector _columnType;
        private readonly uint _columnCount;

        public SpirvMatrix(SpirvVector columnType, uint columnCount)
        {
            _columnType = columnType;
            _columnCount = columnCount;
        }
        
        public override SpirvVector ColumnType => _columnType;
        public override uint ColumnStride => _columnType.Alignment / _columnType.ComponentType.SizeInBytes;
        public override MatrixOrientation MatrixOrientation => MatrixOrientation.ColMajor;
        public override uint ColumnCount => _columnCount;
    }
}