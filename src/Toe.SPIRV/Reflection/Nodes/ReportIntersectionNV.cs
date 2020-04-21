using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReportIntersectionNV : Node
    {
        public ReportIntersectionNV()
        {
        }

        public ReportIntersectionNV(SpirvTypeBase resultType, Node hit, Node hitKind, string debugName = null)
        {
            this.ResultType = resultType;
            this.Hit = hit;
            this.HitKind = hitKind;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpReportIntersectionNV;

        public Node Hit { get; set; }

        public Node HitKind { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Hit), Hit);
                yield return CreateInputPin(nameof(HitKind), HitKind);
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

        public ReportIntersectionNV WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpReportIntersectionNV)op, treeBuilder);
        }

        public ReportIntersectionNV SetUp(Action<ReportIntersectionNV> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpReportIntersectionNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Hit = treeBuilder.GetNode(op.Hit);
            HitKind = treeBuilder.GetNode(op.HitKind);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the ReportIntersectionNV object.</summary>
        /// <returns>A string that represents the ReportIntersectionNV object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"ReportIntersectionNV({ResultType}, {Hit}, {HitKind}, {DebugName})";
        }
    }
}