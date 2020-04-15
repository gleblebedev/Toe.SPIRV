using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvArrayLayout : SpirvArrayBase
    {
        private readonly SpirvArrayBase _arrayType;
        private readonly uint? _arrayStride;

        public SpirvArrayLayout(SpirvArrayBase arrayType, uint? arrayStride = null)
        {
            _arrayType = arrayType;
            _arrayStride = arrayStride;
        }

        public override Op OpCode => Op.OpTypeArray;

        public override uint ArrayStride => _arrayStride ?? _arrayType.ArrayStride;

        public override uint Length => _arrayType.Length;

        public override SpirvTypeBase ElementType => _arrayType.ElementType;
    }
}