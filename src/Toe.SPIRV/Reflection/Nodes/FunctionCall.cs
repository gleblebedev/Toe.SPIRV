using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FunctionCall : ExecutableNode 
    {
        public FunctionCall()
        {
        }

        public Node Function { get; set; }
        public IList<Node> Arguments { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Function), Function);
                for (var index = 0; index < Arguments.Count; index++)
                {
                    yield return CreateInputPin(nameof(Arguments) + index, Arguments[index]);
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
            SetUp((OpFunctionCall)op, treeBuilder);
        }

        public void SetUp(OpFunctionCall op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Function = treeBuilder.GetNode(op.Function);
            Arguments = treeBuilder.GetNodes(op.Arguments);
        }
    }
}