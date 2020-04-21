using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAllEqualKHR : Node
    {
        public SubgroupAllEqualKHR()
        {
        }

        public SubgroupAllEqualKHR(SpirvTypeBase resultType, Node predicate, string debugName = null)
        {
            this.ResultType = resultType;
            this.Predicate = predicate;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAllEqualKHR;

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

        public SubgroupAllEqualKHR WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAllEqualKHR)op, treeBuilder);
        }

        public SubgroupAllEqualKHR SetUp(Action<SubgroupAllEqualKHR> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAllEqualKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Predicate = treeBuilder.GetNode(op.Predicate);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAllEqualKHR object.</summary>
        /// <returns>A string that represents the SubgroupAllEqualKHR object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAllEqualKHR({ResultType}, {Predicate}, {DebugName})";
        }
    }
}