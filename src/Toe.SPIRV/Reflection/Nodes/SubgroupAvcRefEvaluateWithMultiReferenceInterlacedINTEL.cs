using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL : Node
    {
        public SubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL;


        public Node SrcImage { get; set; }
        public Node PackedReferenceIds { get; set; }
        public Node PackedReferenceFieldPolarities { get; set; }
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
                yield return CreateInputPin(nameof(PackedReferenceIds), PackedReferenceIds);
                yield return CreateInputPin(nameof(PackedReferenceFieldPolarities), PackedReferenceFieldPolarities);
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
            SetUp((OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcImage = treeBuilder.GetNode(op.SrcImage);
            PackedReferenceIds = treeBuilder.GetNode(op.PackedReferenceIds);
            PackedReferenceFieldPolarities = treeBuilder.GetNode(op.PackedReferenceFieldPolarities);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }
    }
}