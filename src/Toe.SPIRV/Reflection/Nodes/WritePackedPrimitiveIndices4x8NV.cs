using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class WritePackedPrimitiveIndices4x8NV : ExecutableNode, INodeWithNext
    {
        public WritePackedPrimitiveIndices4x8NV()
        {
        }

        public override Op OpCode => Op.OpWritePackedPrimitiveIndices4x8NV;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node IndexOffset { get; set; }
        public Node PackedIndices { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(IndexOffset), IndexOffset);
                yield return CreateInputPin(nameof(PackedIndices), PackedIndices);
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
            SetUp((OpWritePackedPrimitiveIndices4x8NV)op, treeBuilder);
        }

        public void SetUp(OpWritePackedPrimitiveIndices4x8NV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            IndexOffset = treeBuilder.GetNode(op.IndexOffset);
            PackedIndices = treeBuilder.GetNode(op.PackedIndices);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}