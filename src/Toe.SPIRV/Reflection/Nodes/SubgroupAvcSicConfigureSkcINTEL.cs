using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicConfigureSkcINTEL : Node
    {
        public SubgroupAvcSicConfigureSkcINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcSicConfigureSkcINTEL;


        public Node SkipBlockPartitionType { get; set; }
        public Node SkipMotionVectorMask { get; set; }
        public Node MotionVectors { get; set; }
        public Node BidirectionalWeight { get; set; }
        public Node SadAdjustment { get; set; }
        public Node Payload { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public bool RelaxedPrecision { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SkipBlockPartitionType), SkipBlockPartitionType);
                yield return CreateInputPin(nameof(SkipMotionVectorMask), SkipMotionVectorMask);
                yield return CreateInputPin(nameof(MotionVectors), MotionVectors);
                yield return CreateInputPin(nameof(BidirectionalWeight), BidirectionalWeight);
                yield return CreateInputPin(nameof(SadAdjustment), SadAdjustment);
                yield return CreateInputPin(nameof(Payload), Payload);
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
            SetUp((OpSubgroupAvcSicConfigureSkcINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcSicConfigureSkcINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SkipBlockPartitionType = treeBuilder.GetNode(op.SkipBlockPartitionType);
            SkipMotionVectorMask = treeBuilder.GetNode(op.SkipMotionVectorMask);
            MotionVectors = treeBuilder.GetNode(op.MotionVectors);
            BidirectionalWeight = treeBuilder.GetNode(op.BidirectionalWeight);
            SadAdjustment = treeBuilder.GetNode(op.SadAdjustment);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}