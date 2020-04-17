using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeRefWindowSizeINTEL : Node
    {
        public SubgroupAvcImeRefWindowSizeINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeRefWindowSizeINTEL;


        public Node SearchWindowConfig { get; set; }
        public Node DualRef { get; set; }
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
                yield return CreateInputPin(nameof(SearchWindowConfig), SearchWindowConfig);
                yield return CreateInputPin(nameof(DualRef), DualRef);
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
            SetUp((OpSubgroupAvcImeRefWindowSizeINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeRefWindowSizeINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SearchWindowConfig = treeBuilder.GetNode(op.SearchWindowConfig);
            DualRef = treeBuilder.GetNode(op.DualRef);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}