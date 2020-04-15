using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvMatrixLayout : SpirvMatrixBase
    {
        private readonly SpirvMatrixBase _matrixType;
        private readonly uint? _columnStride;

        public SpirvMatrixLayout(SpirvMatrixBase matrixType,
            MatrixOrientation matrixOrientation = MatrixOrientation.ColMajor, uint? columnStride = null)
        {
            _matrixType = matrixType;
            MatrixOrientation = matrixOrientation;
            _columnStride = columnStride;
        }

        public override Op OpCode => Op.OpTypeMatrix;


        public override SpirvVector ColumnType => _matrixType.ColumnType;
        public override uint ColumnStride => _columnStride ?? _matrixType.ColumnStride;
        public override uint ColumnCount => _matrixType.ColumnCount;

        public override MatrixOrientation MatrixOrientation { get; }
    }
}