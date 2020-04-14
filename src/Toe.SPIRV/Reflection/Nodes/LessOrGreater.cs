using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class LessOrGreater : FunctionNode 
    {
        public LessOrGreater()
        {
        }

        public Node x { get; set; }
        public Node y { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(x), x);
                yield return CreateInputPin(nameof(y), y);
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
            SetUp((OpLessOrGreater)op, treeBuilder);
        }

        public void SetUp(OpLessOrGreater op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            x = treeBuilder.GetNode(op.x);
            y = treeBuilder.GetNode(op.y);
        }
    }
}