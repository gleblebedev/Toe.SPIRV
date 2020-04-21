using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL : Node
    {
        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL()
        {
        }

        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL(SpirvTypeBase resultType, Node payload, Node majorShape, Node direction, string debugName = null)
        {
            this.ResultType = resultType;
            this.Payload = payload;
            this.MajorShape = majorShape;
            this.Direction = direction;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL;

        public Node Payload { get; set; }

        public Node MajorShape { get; set; }

        public Node Direction { get; set; }

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

        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL SetUp(Action<SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Payload = treeBuilder.GetNode(op.Payload);
            MajorShape = treeBuilder.GetNode(op.MajorShape);
            Direction = treeBuilder.GetNode(op.Direction);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL({ResultType}, {Payload}, {MajorShape}, {Direction}, {DebugName})";
        }
    }
}