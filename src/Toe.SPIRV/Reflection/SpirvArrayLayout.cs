using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvArrayLayout : SpirvArray
    {
        private readonly SpirvArray _arrayType;
        private readonly uint? _arrayStride;

        public SpirvArrayLayout(SpirvArray arrayType, uint? arrayStride = null)
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