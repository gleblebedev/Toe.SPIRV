using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAllKHR : Node
    {
        public SubgroupAllKHR()
        {
        }

        public SubgroupAllKHR(SpirvTypeBase resultType, Node predicate, string debugName = null)
        {
            this.ResultType = resultType;
            this.Predicate = predicate;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAllKHR;

        public Node Predicate { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Predicate), Predicate);
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

        public SubgroupAllKHR WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAllKHR)op, treeBuilder);
        }

        public SubgroupAllKHR SetUp(Action<SubgroupAllKHR> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAllKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Predicate = treeBuilder.GetNode(op.Predicate);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAllKHR object.</summary>
        /// <returns>A string that represents the SubgroupAllKHR object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAllKHR({ResultType}, {Predicate}, {DebugName})";
        }
    }
}