using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvFunctionType:SpirvTypeBase
    {
        public SpirvFunctionType():base(SpirvTypeCategory.Function)
        {
        }

        public override Op OpCode => Op.OpTypeFunction;

        public SpirvTypeBase ReturnType { get; set; }

        public IList<SpirvFunctionArgument> Arguments { get; } = new List<SpirvFunctionArgument>();

        public string Name { get; set; }

        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}