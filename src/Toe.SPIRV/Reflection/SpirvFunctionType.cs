using System.Collections.Generic;

namespace Toe.SPIRV.Reflection
{
    public class SpirvFunctionType:SpirvTypeBase
    {
        public SpirvFunctionType():base(SpirvTypeCategory.Function)
        {
        }

        public SpirvTypeBase ReturnType { get; set; }

        public IList<SpirvFunctionArgument> Arguments { get; } = new List<SpirvFunctionArgument>();

        public string Name { get; set; }
    }
}