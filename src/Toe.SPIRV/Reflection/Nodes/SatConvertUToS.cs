using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SatConvertUToS : FunctionNode 
    {
        public SatConvertUToS()
        {
        }

        public Node UnsignedValue { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(UnsignedValue), UnsignedValue);
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
            SetUp((OpSatConvertUToS)op, treeBuilder);
        }

        public void SetUp(OpSatConvertUToS op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            UnsignedValue = treeBuilder.GetNode(op.UnsignedValue);
        }
    }
}