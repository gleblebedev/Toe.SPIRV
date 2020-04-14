using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class InBoundsAccessChain : FunctionNode 
    {
        public InBoundsAccessChain()
        {
        }

        public Node Base { get; set; }
        public IList<Node> Indexes { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Base), Base);
                for (var index = 0; index < Indexes.Count; index++)
                {
                    yield return CreateInputPin(nameof(Indexes) + index, Indexes[index]);
                }
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
            SetUp((OpInBoundsAccessChain)op, treeBuilder);
        }

        public void SetUp(OpInBoundsAccessChain op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Indexes = treeBuilder.GetNodes(op.Indexes);
        }
    }
}