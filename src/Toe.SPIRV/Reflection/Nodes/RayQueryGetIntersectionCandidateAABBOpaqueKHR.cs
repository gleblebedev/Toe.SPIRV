using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class RayQueryGetIntersectionCandidateAABBOpaqueKHR : Node
    {
        public RayQueryGetIntersectionCandidateAABBOpaqueKHR()
        {
        }

        public RayQueryGetIntersectionCandidateAABBOpaqueKHR(SpirvTypeBase resultType, Node rayQuery, string debugName = null)
        {
            this.ResultType = resultType;
            this.RayQuery = rayQuery;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpRayQueryGetIntersectionCandidateAABBOpaqueKHR;

        public Node RayQuery { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(RayQuery), RayQuery);
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

        public RayQueryGetIntersectionCandidateAABBOpaqueKHR WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpRayQueryGetIntersectionCandidateAABBOpaqueKHR)op, treeBuilder);
        }

        public RayQueryGetIntersectionCandidateAABBOpaqueKHR SetUp(Action<RayQueryGetIntersectionCandidateAABBOpaqueKHR> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpRayQueryGetIntersectionCandidateAABBOpaqueKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            RayQuery = treeBuilder.GetNode(op.RayQuery);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the RayQueryGetIntersectionCandidateAABBOpaqueKHR object.</summary>
        /// <returns>A string that represents the RayQueryGetIntersectionCandidateAABBOpaqueKHR object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"RayQueryGetIntersectionCandidateAABBOpaqueKHR({ResultType}, {RayQuery}, {DebugName})";
        }
    }
}