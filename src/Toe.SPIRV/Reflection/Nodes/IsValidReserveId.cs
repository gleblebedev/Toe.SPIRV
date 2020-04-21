using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class IsValidReserveId : Node
    {
        public IsValidReserveId()
        {
        }

        public IsValidReserveId(SpirvTypeBase resultType, Node reserveId, string debugName = null)
        {
            this.ResultType = resultType;
            this.ReserveId = reserveId;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpIsValidReserveId;

        public Node ReserveId { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(ReserveId), ReserveId);
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

        public IsValidReserveId WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpIsValidReserveId)op, treeBuilder);
        }

        public IsValidReserveId SetUp(Action<IsValidReserveId> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpIsValidReserveId op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            ReserveId = treeBuilder.GetNode(op.ReserveId);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the IsValidReserveId object.</summary>
        /// <returns>A string that represents the IsValidReserveId object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"IsValidReserveId({ResultType}, {ReserveId}, {DebugName})";
        }
    }
}