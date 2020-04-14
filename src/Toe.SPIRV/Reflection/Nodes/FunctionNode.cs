using System.Collections.Generic;

namespace Toe.SPIRV.Reflection.Nodes
{
    public abstract class FunctionNode: Node
    {
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield return new NodePin(this, "", GetResultType());
            }
        }
    }
}