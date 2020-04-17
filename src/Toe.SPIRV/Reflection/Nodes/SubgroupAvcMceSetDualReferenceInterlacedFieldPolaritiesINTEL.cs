using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL : Node
    {
        public SubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL;


        public Node ForwardReferenceFieldPolarity { get; set; }
        public Node BackwardReferenceFieldPolarity { get; set; }
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
                yield return CreateInputPin(nameof(ForwardReferenceFieldPolarity), ForwardReferenceFieldPolarity);
                yield return CreateInputPin(nameof(BackwardReferenceFieldPolarity), BackwardReferenceFieldPolarity);
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
            SetUp((OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            ForwardReferenceFieldPolarity = treeBuilder.GetNode(op.ForwardReferenceFieldPolarity);
            BackwardReferenceFieldPolarity = treeBuilder.GetNode(op.BackwardReferenceFieldPolarity);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}