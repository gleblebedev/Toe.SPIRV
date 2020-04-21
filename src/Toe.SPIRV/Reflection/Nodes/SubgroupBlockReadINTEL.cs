using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupBlockReadINTEL : Node
    {
        public SubgroupBlockReadINTEL()
        {
        }

        public SubgroupBlockReadINTEL(SpirvTypeBase resultType, Node ptr, string debugName = null)
        {
            this.ResultType = resultType;
            this.Ptr = ptr;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupBlockReadINTEL;

        public Node Ptr { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Ptr), Ptr);
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

        public SubgroupBlockReadINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupBlockReadINTEL)op, treeBuilder);
        }

        public SubgroupBlockReadINTEL SetUp(Action<SubgroupBlockReadINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupBlockReadINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Ptr = treeBuilder.GetNode(op.Ptr);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupBlockReadINTEL object.</summary>
        /// <returns>A string that represents the SubgroupBlockReadINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupBlockReadINTEL({ResultType}, {Ptr}, {DebugName})";
        }
    }
}