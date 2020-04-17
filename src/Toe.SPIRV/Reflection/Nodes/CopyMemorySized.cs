using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CopyMemorySized : ExecutableNode, INodeWithNext
    {
        public CopyMemorySized()
        {
        }

        public override Op OpCode => Op.OpCopyMemorySized;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node Target { get; set; }
        public Node Source { get; set; }
        public Node Size { get; set; }
        public Spv.MemoryAccess MemoryAccess { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Target), Target);
                yield return CreateInputPin(nameof(Source), Source);
                yield return CreateInputPin(nameof(Size), Size);
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
            SetUp((OpCopyMemorySized)op, treeBuilder);
        }

        public void SetUp(OpCopyMemorySized op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Source = treeBuilder.GetNode(op.Source);
            Size = treeBuilder.GetNode(op.Size);
            MemoryAccess = op.MemoryAccess;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}