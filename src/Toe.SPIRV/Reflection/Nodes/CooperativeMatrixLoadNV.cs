using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CooperativeMatrixLoadNV : Node
    {
        public CooperativeMatrixLoadNV()
        {
        }

        public override Op OpCode => Op.OpCooperativeMatrixLoadNV;


        public Node Pointer { get; set; }
        public Node Stride { get; set; }
        public Node ColumnMajor { get; set; }
        public Spv.MemoryAccess MemoryAccess { get; set; }
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
                yield return CreateInputPin(nameof(Pointer), Pointer);
                yield return CreateInputPin(nameof(Stride), Stride);
                yield return CreateInputPin(nameof(ColumnMajor), ColumnMajor);
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
            SetUp((OpCooperativeMatrixLoadNV)op, treeBuilder);
        }

        public void SetUp(OpCooperativeMatrixLoadNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            Stride = treeBuilder.GetNode(op.Stride);
            ColumnMajor = treeBuilder.GetNode(op.ColumnMajor);
            MemoryAccess = op.MemoryAccess;
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}