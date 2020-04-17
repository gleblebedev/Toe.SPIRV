using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CooperativeMatrixMulAddNV : Node
    {
        public CooperativeMatrixMulAddNV()
        {
        }

        public override Op OpCode => Op.OpCooperativeMatrixMulAddNV;


        public Node A { get; set; }
        public Node B { get; set; }
        public Node C { get; set; }
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
                yield return CreateInputPin(nameof(A), A);
                yield return CreateInputPin(nameof(B), B);
                yield return CreateInputPin(nameof(C), C);
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
            SetUp((OpCooperativeMatrixMulAddNV)op, treeBuilder);
        }

        public void SetUp(OpCooperativeMatrixMulAddNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            A = treeBuilder.GetNode(op.A);
            B = treeBuilder.GetNode(op.B);
            C = treeBuilder.GetNode(op.C);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}