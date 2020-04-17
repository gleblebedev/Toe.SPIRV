using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvMatrixDeclaration : SpirvMatrix
    {
        private readonly SpirvVector _columnType;

        public SpirvMatrixDeclaration(SpirvVector columnType, uint columnCount)
        {
            _columnType = columnType;
            ColumnCount = columnCount;
        }

        public override Op OpCode => Op.OpTypeMatrix;

        public override SpirvVector ColumnType => _columnType;
        public override uint ColumnStride => _columnType.Alignment;
        public override MatrixOrientation MatrixOrientation => MatrixOrientation.ColMajor;
        public override uint ColumnCount { get; }
    }
}