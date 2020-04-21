using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL : Node
    {
        public SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL()
        {
        }

        public SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL(SpirvTypeBase resultType, Node payload, Node majorShape, string debugName = null)
        {
            this.ResultType = resultType;
            this.Payload = payload;
            this.MajorShape = majorShape;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL;

        public Node Payload { get; set; }

        public Node MajorShape { get; set; }

        public SpirvTypeBase ResultType { get; set; }

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

        public SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL SetUp(Action<SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Payload = treeBuilder.GetNode(op.Payload);
            MajorShape = treeBuilder.GetNode(op.MajorShape);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL({ResultType}, {Payload}, {MajorShape}, {DebugName})";
        }
    }
}