using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeSetSingleReferenceINTEL : Node
    {
        public SubgroupAvcImeSetSingleReferenceINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcImeSetSingleReferenceINTEL;


        public Node RefOffset { get; set; }
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
                yield return CreateInputPin(nameof(RefOffset), RefOffset);
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
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeSetSingleReferenceINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcImeSetSingleReferenceINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            RefOffset = treeBuilder.GetNode(op.RefOffset);
            SearchWindowConfig = treeBuilder.GetNode(op.SearchWindowConfig);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }
    }
}