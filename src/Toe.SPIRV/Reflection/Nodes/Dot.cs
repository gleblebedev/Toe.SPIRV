using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Dot : FunctionNode 
    {
        public Dot()
        {
        }

        public Node Vector1 { get; set; }
        public Node Vector2 { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Vector1), Vector1);
                yield return CreateInputPin(nameof(Vector2), Vector2);
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
            SetUp((OpDot)op, treeBuilder);
        }

        public void SetUp(OpDot op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector1 = treeBuilder.GetNode(op.Vector1);
            Vector2 = treeBuilder.GetNode(op.Vector2);
        }
    }
}