using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeInitializeINTEL : Node
    {
        public SubgroupAvcImeInitializeINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeInitializeINTEL;


        public Node SrcCoord { get; set; }
        public Node PartitionMask { get; set; }
        public Node SADAdjustment { get; set; }
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
                yield return CreateInputPin(nameof(SrcCoord), SrcCoord);
                yield return CreateInputPin(nameof(PartitionMask), PartitionMask);
                yield return CreateInputPin(nameof(SADAdjustment), SADAdjustment);
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
            SetUp((OpSubgroupAvcImeInitializeINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeInitializeINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcCoord = treeBuilder.GetNode(op.SrcCoord);
            PartitionMask = treeBuilder.GetNode(op.PartitionMask);
            SADAdjustment = treeBuilder.GetNode(op.SADAdjustment);
            SetUpDecorations(op, treeBuilder);
        }
    }
}