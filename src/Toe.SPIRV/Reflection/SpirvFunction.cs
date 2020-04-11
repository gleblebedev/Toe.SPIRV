using System.Collections;
using System.Collections.Generic;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvFunction: SequentialOperationNode
    {
        public SpirvFunction()
        {
        }

        public SpirvTypeBase ReturnType { get; set; } = SpirvTypeBase.Void;

        public IList<FunctionParameter> Arguments { get; } = new List<FunctionParameter>();

        public string Name { get; set; }
        public FunctionControl FunctionControl { get; set; } = FunctionControl.None;
    }
}