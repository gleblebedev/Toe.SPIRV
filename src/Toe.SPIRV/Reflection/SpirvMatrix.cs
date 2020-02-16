namespace Toe.SPIRV.Reflection
{
    public class SpirvMatrix : SpirvMatrixBase
    {
        private readonly SpirvVector _columnType;

        public SpirvMatrix(SpirvVector columnType, uint columnCount)
        {
            _columnType = columnType;
            ColumnCount = columnCount;
        }

        public override SpirvVector ColumnType => _columnType;
        public override uint ColumnStride => _columnType.Alignment;
        public override MatrixOrientation MatrixOrientation => MatrixOrientation.ColMajor;
        public override uint ColumnCount { get; }
    }
}