using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FunctionParameter : FunctionNode 
    {
        public FunctionParameter()
        {
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
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
            SetUp((OpFunctionParameter)op, treeBuilder);
        }

        public void SetUp(OpFunctionParameter op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
        }
    }
}