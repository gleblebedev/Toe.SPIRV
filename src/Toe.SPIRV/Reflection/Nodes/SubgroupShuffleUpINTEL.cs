using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupShuffleUpINTEL : Node
    {
        public SubgroupShuffleUpINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupShuffleUpINTEL;


        public Node Previous { get; set; }
        public Node Current { get; set; }
        public Node Delta { get; set; }
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
                yield return CreateInputPin(nameof(Previous), Previous);
                yield return CreateInputPin(nameof(Current), Current);
                yield return CreateInputPin(nameof(Delta), Delta);
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
            SetUp((OpSubgroupShuffleUpINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupShuffleUpINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Previous = treeBuilder.GetNode(op.Previous);
            Current = treeBuilder.GetNode(op.Current);
            Delta = treeBuilder.GetNode(op.Delta);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}