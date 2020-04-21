using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class NamedBarrierInitialize : Node
    {
        public NamedBarrierInitialize()
        {
        }

        public NamedBarrierInitialize(SpirvTypeBase resultType, Node subgroupCount, string debugName = null)
        {
            this.ResultType = resultType;
            this.SubgroupCount = subgroupCount;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpNamedBarrierInitialize;

        public Node SubgroupCount { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SubgroupCount), SubgroupCount);
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

        public NamedBarrierInitialize WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpNamedBarrierInitialize)op, treeBuilder);
        }

        public NamedBarrierInitialize SetUp(Action<NamedBarrierInitialize> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpNamedBarrierInitialize op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SubgroupCount = treeBuilder.GetNode(op.SubgroupCount);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the NamedBarrierInitialize object.</summary>
        /// <returns>A string that represents the NamedBarrierInitialize object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"NamedBarrierInitialize({ResultType}, {SubgroupCount}, {DebugName})";
        }
    }
}