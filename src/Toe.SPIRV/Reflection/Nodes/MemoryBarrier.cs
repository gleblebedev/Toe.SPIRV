using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemoryBarrier : ExecutableNode, INodeWithNext
    {
        public MemoryBarrier()
        {
        }

        public override Op OpCode => Op.OpMemoryBarrier;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

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
            SetUp((OpMemoryBarrier)op, treeBuilder);
        }

        public void SetUp(OpMemoryBarrier op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Memory = op.Memory;
            Semantics = op.Semantics;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}