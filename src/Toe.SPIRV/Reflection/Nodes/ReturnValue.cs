using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReturnValue : ExecutableNode
    {
        public ReturnValue()
        {
        }

        public override Op OpCode => Op.OpReturnValue;


        public Node Value { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Value), Value);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> EnterPins
        {
            get
            {
                yield return new NodePin(this, "", null);
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
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
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}