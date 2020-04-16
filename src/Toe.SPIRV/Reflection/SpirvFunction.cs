using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvFunction:SpirvTypeBase
    {
        public SpirvFunction():base(SpirvTypeCategory.Function)
        {
        }

        public override Op OpCode => Op.OpTypeFunction;

        public SpirvTypeBase ReturnType { get; set; }

        public IList<SpirvFunctionArgument> Arguments { get; } = new List<SpirvFunctionArgument>();

        public override string ToString()
        {
            return DebugName ?? base.ToString();
        }
    }
}