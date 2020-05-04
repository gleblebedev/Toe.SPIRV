using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR : Node
    {
        public RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR()
        {
        }

        public RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR(SpirvTypeBase resultType, Node rayQuery, Node intersection, string debugName = null)
        {
            this.ResultType = resultType;
            this.RayQuery = rayQuery;
            this.Intersection = intersection;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR;

        public Node RayQuery { get; set; }

        public Node Intersection { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<Node> GetInputNodes()
        {
                yield return RayQuery;
                yield return Intersection;
        }

        public RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR)op, treeBuilder);
        }

        public RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR SetUp(Action<RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            RayQuery = treeBuilder.GetNode(op.RayQuery);
            Intersection = treeBuilder.GetNode(op.Intersection);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR object.</summary>
        /// <returns>A string that represents the RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR({ResultType}, {RayQuery}, {Intersection}, {DebugName})";
        }
    }
}