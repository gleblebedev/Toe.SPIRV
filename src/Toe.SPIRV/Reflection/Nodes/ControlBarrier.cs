using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ControlBarrier : ExecutableNode, INodeWithNext
    {
        public ControlBarrier()
        {
        }

        public override Op OpCode => Op.OpControlBarrier;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public uint Execution { get; set; }
        public uint Memory { get; set; }
        public uint Semantics { get; set; }

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
            SetUp((OpControlBarrier)op, treeBuilder);
        }

        public void SetUp(OpControlBarrier op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Execution = op.Execution;
            Memory = op.Memory;
            Semantics = op.Semantics;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}