using System.Collections.Generic;
using Toe.SPIRV.Reflection.Types;

namespace Toe.SPIRV.Reflection.Nodes
{
    public abstract class FunctionNode: Node
    {
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
    }
}