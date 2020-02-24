using System.Collections;
using System.Collections.Generic;

namespace Toe.SPIRV.Reflection
{
    public class SpirvFunction
    {
        public SpirvFunction()
        {
        }

        public SpirvTypeBase ReturnType { get; set; }

        public IList<SpirvFunctionArgument> Arguments { get; } = new List<SpirvFunctionArgument>();

        public string Name { get; set; }
    }
}