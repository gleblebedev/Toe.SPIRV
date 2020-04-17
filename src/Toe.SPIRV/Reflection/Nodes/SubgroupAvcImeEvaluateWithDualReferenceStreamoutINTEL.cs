using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL : Node
    {
        public SubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL;


        public Node SrcImage { get; set; }
        public Node FwdRefImage { get; set; }
        public Node BwdRefImage { get; set; }
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
                yield return CreateInputPin(nameof(SrcImage), SrcImage);
                yield return CreateInputPin(nameof(FwdRefImage), FwdRefImage);
                yield return CreateInputPin(nameof(BwdRefImage), BwdRefImage);
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
            SetUp((OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcImage = treeBuilder.GetNode(op.SrcImage);
            FwdRefImage = treeBuilder.GetNode(op.FwdRefImage);
            BwdRefImage = treeBuilder.GetNode(op.BwdRefImage);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}