using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GenericPtrMemSemantics : FunctionNode 
    {
        public GenericPtrMemSemantics()
        {
        }

        public Node Pointer { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
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
            SetUp((OpGenericPtrMemSemantics)op, treeBuilder);
        }

        public void SetUp(OpGenericPtrMemSemantics op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
        }
    }
}