using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicGetMotionVectorMaskINTEL : Node
    {
        public SubgroupAvcSicGetMotionVectorMaskINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcSicGetMotionVectorMaskINTEL;


        public Node SkipBlockPartitionType { get; set; }
        public Node Direction { get; set; }
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
                yield return CreateInputPin(nameof(Direction), Direction);
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
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcSicGetMotionVectorMaskINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcSicGetMotionVectorMaskINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SkipBlockPartitionType = treeBuilder.GetNode(op.SkipBlockPartitionType);
            Direction = treeBuilder.GetNode(op.Direction);
            SetUpDecorations(op, treeBuilder);
        }
    }
}