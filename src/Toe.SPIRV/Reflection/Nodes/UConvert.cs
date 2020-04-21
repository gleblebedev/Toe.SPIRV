using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class UConvert : Node
    {
        public UConvert()
        {
        }

        public UConvert(SpirvTypeBase resultType, Node unsignedValue, string debugName = null)
        {
            this.ResultType = resultType;
            this.UnsignedValue = unsignedValue;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpUConvert;

        public Node UnsignedValue { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(UnsignedValue), UnsignedValue);
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

        public UConvert WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpUConvert)op, treeBuilder);
        }

        public UConvert SetUp(Action<UConvert> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpUConvert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            UnsignedValue = treeBuilder.GetNode(op.UnsignedValue);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the UConvert object.</summary>
        /// <returns>A string that represents the UConvert object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"UConvert({ResultType}, {UnsignedValue}, {DebugName})";
        }
    }
}