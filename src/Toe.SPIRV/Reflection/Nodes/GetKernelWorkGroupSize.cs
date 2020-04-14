using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GetKernelWorkGroupSize : FunctionNode 
    {
        public GetKernelWorkGroupSize()
        {
        }

        public Node Invoke { get; set; }
        public Node Param { get; set; }
        public Node ParamSize { get; set; }
        public Node ParamAlign { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Invoke), Invoke);
                yield return CreateInputPin(nameof(Param), Param);
                yield return CreateInputPin(nameof(ParamSize), ParamSize);
                yield return CreateInputPin(nameof(ParamAlign), ParamAlign);
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
            SetUp((OpGetKernelWorkGroupSize)op, treeBuilder);
        }

        public void SetUp(OpGetKernelWorkGroupSize op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Invoke = treeBuilder.GetNode(op.Invoke);
            Param = treeBuilder.GetNode(op.Param);
            ParamSize = treeBuilder.GetNode(op.ParamSize);
            ParamAlign = treeBuilder.GetNode(op.ParamAlign);
        }
    }
}