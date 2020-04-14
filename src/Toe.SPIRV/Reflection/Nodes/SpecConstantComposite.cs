using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SpecConstantComposite : FunctionNode 
    {
        public SpecConstantComposite()
        {
        }

        public IList<Node> Constituents { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                for (var index = 0; index < Constituents.Count; index++)
                {
                    yield return CreateInputPin(nameof(Constituents) + index, Constituents[index]);
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
            SetUp((OpSpecConstantComposite)op, treeBuilder);
        }

        public void SetUp(OpSpecConstantComposite op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Constituents = treeBuilder.GetNodes(op.Constituents);
        }
    }
}