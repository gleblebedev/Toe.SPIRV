using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ExecutionModeId : ExecutableNode, INodeWithNext
    {
        public ExecutionModeId()
        {
        }

        public override Op OpCode => Op.OpExecutionModeId;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

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
                yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpExecutionModeId)op, treeBuilder);
        }

        public void SetUp(OpExecutionModeId op, SpirvInstructionTreeBuilder treeBuilder)
        {
            EntryPoint = treeBuilder.GetNode(op.EntryPoint);
            Mode = op.Mode;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}