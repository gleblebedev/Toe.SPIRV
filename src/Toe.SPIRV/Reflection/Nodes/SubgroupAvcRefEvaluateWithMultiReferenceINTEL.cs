using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcRefEvaluateWithMultiReferenceINTEL : Node
    {
        public SubgroupAvcRefEvaluateWithMultiReferenceINTEL()
        {
        }

        public SubgroupAvcRefEvaluateWithMultiReferenceINTEL(SpirvTypeBase resultType, Node srcImage, Node packedReferenceIds, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.SrcImage = srcImage;
            this.PackedReferenceIds = packedReferenceIds;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL;

        public Node SrcImage { get; set; }

        public Node PackedReferenceIds { get; set; }

        public Node Payload { get; set; }

        public SpirvTypeBase ResultType { get; set; }

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

        public SubgroupAvcRefEvaluateWithMultiReferenceINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL)op, treeBuilder);
        }

        public SubgroupAvcRefEvaluateWithMultiReferenceINTEL SetUp(Action<SubgroupAvcRefEvaluateWithMultiReferenceINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcImage = treeBuilder.GetNode(op.SrcImage);
            PackedReferenceIds = treeBuilder.GetNode(op.PackedReferenceIds);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcRefEvaluateWithMultiReferenceINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcRefEvaluateWithMultiReferenceINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcRefEvaluateWithMultiReferenceINTEL({ResultType}, {SrcImage}, {PackedReferenceIds}, {Payload}, {DebugName})";
        }
    }
}