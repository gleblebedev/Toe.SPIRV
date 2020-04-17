using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicFlagClear : ExecutableNode, INodeWithNext
    {
        public AtomicFlagClear()
        {
        }

        public override Op OpCode => Op.OpAtomicFlagClear;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node Pointer { get; set; }
        public uint Memory { get; set; }
        public uint Semantics { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
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
            SetUp((OpAtomicFlagClear)op, treeBuilder);
        }

        public void SetUp(OpAtomicFlagClear op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
            Memory = op.Memory;
            Semantics = op.Semantics;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}