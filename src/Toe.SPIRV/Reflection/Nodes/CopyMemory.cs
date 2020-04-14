using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CopyMemory : ExecutableNode 
    {
        public CopyMemory()
        {
        }

        public Node Target { get; set; }
        public Node Source { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Target), Target);
                yield return CreateInputPin(nameof(Source), Source);
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
            SetUp((OpCopyMemory)op, treeBuilder);
        }

        public void SetUp(OpCopyMemory op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Source = treeBuilder.GetNode(op.Source);
        }
    }
}