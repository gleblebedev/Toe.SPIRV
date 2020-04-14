using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupUMaxNonUniformAMD : FunctionNode 
    {
        public GroupUMaxNonUniformAMD()
        {
        }

        public Node X { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(X), X);
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
            SetUp((OpGroupUMaxNonUniformAMD)op, treeBuilder);
        }

        public void SetUp(OpGroupUMaxNonUniformAMD op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            X = treeBuilder.GetNode(op.X);
        }
    }
}