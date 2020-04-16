using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ExecutionMode : Node
    {
        public ExecutionMode()
        {
        }

        public override Op OpCode => Op.OpExecutionMode;


        public Node EntryPoint { get; set; }
        public Spv.ExecutionMode Mode { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(EntryPoint), EntryPoint);
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


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpExecutionMode)op, treeBuilder);
        }

        public void SetUp(OpExecutionMode op, SpirvInstructionTreeBuilder treeBuilder)
        {
            EntryPoint = treeBuilder.GetNode(op.EntryPoint);
            Mode = op.Mode;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}