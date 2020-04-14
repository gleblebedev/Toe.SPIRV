using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GetKernelNDrangeSubGroupCount : Node
    {
        public GetKernelNDrangeSubGroupCount()
        {
        }

        public override Op OpCode => Op.OpGetKernelNDrangeSubGroupCount;


        public Node NDRange { get; set; }
        public Node Invoke { get; set; }
        public Node Param { get; set; }
        public Node ParamSize { get; set; }
        public Node ParamAlign { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(NDRange), NDRange);
                yield return CreateInputPin(nameof(Invoke), Invoke);
                yield return CreateInputPin(nameof(Param), Param);
                yield return CreateInputPin(nameof(ParamSize), ParamSize);
                yield return CreateInputPin(nameof(ParamAlign), ParamAlign);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield return new NodePin(this, "", ResultType);
                yield break;
            }
        }


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpGetKernelNDrangeSubGroupCount)op, treeBuilder);
        }

        public void SetUp(OpGetKernelNDrangeSubGroupCount op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            NDRange = treeBuilder.GetNode(op.NDRange);
            Invoke = treeBuilder.GetNode(op.Invoke);
            Param = treeBuilder.GetNode(op.Param);
            ParamSize = treeBuilder.GetNode(op.ParamSize);
            ParamAlign = treeBuilder.GetNode(op.ParamAlign);
        }
    }
}