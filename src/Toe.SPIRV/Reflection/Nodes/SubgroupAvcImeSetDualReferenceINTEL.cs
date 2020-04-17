using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeSetDualReferenceINTEL : Node
    {
        public SubgroupAvcImeSetDualReferenceINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeSetDualReferenceINTEL;


        public Node FwdRefOffset { get; set; }
        public Node BwdRefOffset { get; set; }
        public Node SearchWindowConfig { get; set; }
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
                yield return CreateInputPin(nameof(FwdRefOffset), FwdRefOffset);
                yield return CreateInputPin(nameof(BwdRefOffset), BwdRefOffset);
                yield return CreateInputPin(nameof(SearchWindowConfig), SearchWindowConfig);
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
            SetUp((OpSubgroupAvcImeSetDualReferenceINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeSetDualReferenceINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            FwdRefOffset = treeBuilder.GetNode(op.FwdRefOffset);
            BwdRefOffset = treeBuilder.GetNode(op.BwdRefOffset);
            SearchWindowConfig = treeBuilder.GetNode(op.SearchWindowConfig);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}