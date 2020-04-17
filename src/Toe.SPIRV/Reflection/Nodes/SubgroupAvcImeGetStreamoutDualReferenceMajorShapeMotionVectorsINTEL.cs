using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL : Node
    {
        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL;


        public Node Payload { get; set; }
        public Node MajorShape { get; set; }
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
                yield return CreateInputPin(nameof(Payload), Payload);
                yield return CreateInputPin(nameof(MajorShape), MajorShape);
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
            SetUp((OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Payload = treeBuilder.GetNode(op.Payload);
            MajorShape = treeBuilder.GetNode(op.MajorShape);
            Direction = treeBuilder.GetNode(op.Direction);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}