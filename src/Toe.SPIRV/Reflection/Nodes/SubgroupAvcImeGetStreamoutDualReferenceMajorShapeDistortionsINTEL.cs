using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL : Node
    {
        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL()
        {
        }

        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL(SpirvTypeBase resultType, Node payload, Node majorShape, Node direction, string debugName = null)
        {
            this.ResultType = resultType;
            this.Payload = payload;
            this.MajorShape = majorShape;
            this.Direction = direction;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL;

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

        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL SetUp(Action<SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Payload = treeBuilder.GetNode(op.Payload);
            MajorShape = treeBuilder.GetNode(op.MajorShape);
            Direction = treeBuilder.GetNode(op.Direction);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL({ResultType}, {Payload}, {MajorShape}, {Direction}, {DebugName})";
        }
    }
}