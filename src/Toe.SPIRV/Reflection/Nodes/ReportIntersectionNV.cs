using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReportIntersectionNV : Node
    {
        public ReportIntersectionNV()
        {
        }

        public override Op OpCode => Op.OpReportIntersectionNV;


        public Node Hit { get; set; }
        public Node HitKind { get; set; }
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
                yield return CreateInputPin(nameof(Hit), Hit);
                yield return CreateInputPin(nameof(HitKind), HitKind);
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
            SetUp((OpReportIntersectionNV)op, treeBuilder);
        }

        public void SetUp(OpReportIntersectionNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Hit = treeBuilder.GetNode(op.Hit);
            HitKind = treeBuilder.GetNode(op.HitKind);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}