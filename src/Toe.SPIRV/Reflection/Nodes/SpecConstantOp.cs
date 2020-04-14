using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SpecConstantOp : FunctionNode 
    {
        public SpecConstantOp()
        {
        }

        public IList<Node> Operands { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                for (var index = 0; index < Operands.Count; index++)
                {
                    yield return CreateInputPin(nameof(Operands) + index, Operands[index]);
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
            SetUp((OpSpecConstantOp)op, treeBuilder);
        }

        public void SetUp(OpSpecConstantOp op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Operands = treeBuilder.GetNodes(op.Operands);
        }
    }
}