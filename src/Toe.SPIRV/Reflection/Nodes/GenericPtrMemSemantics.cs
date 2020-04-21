using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GenericPtrMemSemantics : Node
    {
        public GenericPtrMemSemantics()
        {
        }

        public GenericPtrMemSemantics(SpirvTypeBase resultType, Node pointer, string debugName = null)
        {
            this.ResultType = resultType;
            this.Pointer = pointer;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGenericPtrMemSemantics;

        public Node Pointer { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
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

        public GenericPtrMemSemantics WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGenericPtrMemSemantics)op, treeBuilder);
        }

        public GenericPtrMemSemantics SetUp(Action<GenericPtrMemSemantics> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGenericPtrMemSemantics op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GenericPtrMemSemantics object.</summary>
        /// <returns>A string that represents the GenericPtrMemSemantics object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GenericPtrMemSemantics({ResultType}, {Pointer}, {DebugName})";
        }
    }
}