using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EnqueueKernel : Node
    {
        public EnqueueKernel()
        {
        }

        public override Op OpCode => Op.OpEnqueueKernel;


        public Node Queue { get; set; }
        public Node Flags { get; set; }
        public Node NDRange { get; set; }
        public Node NumEvents { get; set; }
        public Node WaitEvents { get; set; }
        public Node RetEvent { get; set; }
        public Node Invoke { get; set; }
        public Node Param { get; set; }
        public Node ParamSize { get; set; }
        public Node ParamAlign { get; set; }
        public IList<Node> LocalSize { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Queue), Queue);
                yield return CreateInputPin(nameof(Flags), Flags);
                yield return CreateInputPin(nameof(NDRange), NDRange);
                yield return CreateInputPin(nameof(NumEvents), NumEvents);
                yield return CreateInputPin(nameof(WaitEvents), WaitEvents);
                yield return CreateInputPin(nameof(RetEvent), RetEvent);
                yield return CreateInputPin(nameof(Invoke), Invoke);
                yield return CreateInputPin(nameof(Param), Param);
                yield return CreateInputPin(nameof(ParamSize), ParamSize);
                yield return CreateInputPin(nameof(ParamAlign), ParamAlign);
                for (var index = 0; index < LocalSize.Count; index++)
                {
                    yield return CreateInputPin(nameof(LocalSize) + index, LocalSize[index]);
                }
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
            SetUp((OpEnqueueKernel)op, treeBuilder);
        }

        public void SetUp(OpEnqueueKernel op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Queue = treeBuilder.GetNode(op.Queue);
            Flags = treeBuilder.GetNode(op.Flags);
            NDRange = treeBuilder.GetNode(op.NDRange);
            NumEvents = treeBuilder.GetNode(op.NumEvents);
            WaitEvents = treeBuilder.GetNode(op.WaitEvents);
            RetEvent = treeBuilder.GetNode(op.RetEvent);
            Invoke = treeBuilder.GetNode(op.Invoke);
            Param = treeBuilder.GetNode(op.Param);
            ParamSize = treeBuilder.GetNode(op.ParamSize);
            ParamAlign = treeBuilder.GetNode(op.ParamAlign);
            LocalSize = treeBuilder.GetNodes(op.LocalSize);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}