using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeAdjustRefOffsetINTEL : Node
    {
        public SubgroupAvcImeAdjustRefOffsetINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeAdjustRefOffsetINTEL;


        public Node RefOffset { get; set; }
        public Node SrcCoord { get; set; }
        public Node RefWindowSize { get; set; }
        public Node ImageSize { get; set; }
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
                yield return CreateInputPin(nameof(RefOffset), RefOffset);
                yield return CreateInputPin(nameof(SrcCoord), SrcCoord);
                yield return CreateInputPin(nameof(RefWindowSize), RefWindowSize);
                yield return CreateInputPin(nameof(ImageSize), ImageSize);
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
            SetUp((OpSubgroupAvcImeAdjustRefOffsetINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeAdjustRefOffsetINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            RefOffset = treeBuilder.GetNode(op.RefOffset);
            SrcCoord = treeBuilder.GetNode(op.SrcCoord);
            RefWindowSize = treeBuilder.GetNode(op.RefWindowSize);
            ImageSize = treeBuilder.GetNode(op.ImageSize);
            SetUpDecorations(op, treeBuilder);
        }
    }
}