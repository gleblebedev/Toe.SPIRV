using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL : Node
    {
        public SubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL;


        public Node SourceFieldPolarity { get; set; }
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
                yield return CreateInputPin(nameof(SourceFieldPolarity), SourceFieldPolarity);
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
            SetUp((OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SourceFieldPolarity = treeBuilder.GetNode(op.SourceFieldPolarity);
            Payload = treeBuilder.GetNode(op.Payload);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}