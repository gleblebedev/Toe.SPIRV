using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ShiftRightLogical : FunctionNode 
    {
        public ShiftRightLogical()
        {
        }

        public Node Base { get; set; }
        public Node Shift { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Base), Base);
                yield return CreateInputPin(nameof(Shift), Shift);
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
            SetUp((OpShiftRightLogical)op, treeBuilder);
        }

        public void SetUp(OpShiftRightLogical op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Shift = treeBuilder.GetNode(op.Shift);
        }
    }
}