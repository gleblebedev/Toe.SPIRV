using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ExtInst : FunctionNode 
    {
        public ExtInst()
        {
        }

        public Node Set { get; set; }
        public IList<Node> Operands { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Set), Set);
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
            SetUp((OpExtInst)op, treeBuilder);
        }

        public void SetUp(OpExtInst op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Set = treeBuilder.GetNode(op.Set);
            Operands = treeBuilder.GetNodes(op.Operands);
        }
    }
}