using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvArrayDefinition : SpirvArray
    {
        private readonly SpirvTypeBase _elementType;

        public SpirvArrayDefinition(SpirvTypeBase elementType, uint length)
        {
            _elementType = elementType;
            Length = length;
        }

        public override Op OpCode => Op.OpTypeArray;

        public override uint ArrayStride => SpirvUtils.RoundUp(_elementType.SizeInBytes, 16);

        public override SpirvTypeBase ElementType => _elementType;

        public override uint Length { get; }
    }
}