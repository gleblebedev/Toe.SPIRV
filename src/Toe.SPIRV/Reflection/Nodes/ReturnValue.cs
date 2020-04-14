using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReturnValue : ExecutableNode 
    {
        public ReturnValue()
        {
        }

        public Node Value { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Value), Value);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpReturnValue)op, treeBuilder);
        }

        public void SetUp(OpReturnValue op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Value = treeBuilder.GetNode(op.Value);
        }
    }
}