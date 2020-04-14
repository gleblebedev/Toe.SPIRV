using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Select : FunctionNode 
    {
        public Select()
        {
        }

        public Node Condition { get; set; }
        public Node Object1 { get; set; }
        public Node Object2 { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Condition), Condition);
                yield return CreateInputPin(nameof(Object1), Object1);
                yield return CreateInputPin(nameof(Object2), Object2);
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
            SetUp((OpSelect)op, treeBuilder);
        }

        public void SetUp(OpSelect op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Condition = treeBuilder.GetNode(op.Condition);
            Object1 = treeBuilder.GetNode(op.Object1);
            Object2 = treeBuilder.GetNode(op.Object2);
        }
    }
}