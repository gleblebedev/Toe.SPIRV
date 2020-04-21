using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorExtractDynamic : Node
    {
        public VectorExtractDynamic()
        {
        }

        public VectorExtractDynamic(SpirvTypeBase resultType, Node vector, Node index, string debugName = null)
        {
            this.ResultType = resultType;
            this.Vector = vector;
            this.Index = index;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpVectorExtractDynamic;

        public Node Vector { get; set; }

        public Node Index { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Vector), Vector);
                yield return CreateInputPin(nameof(Index), Index);
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

        public VectorExtractDynamic WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpVectorExtractDynamic)op, treeBuilder);
        }

        public VectorExtractDynamic SetUp(Action<VectorExtractDynamic> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpVectorExtractDynamic op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Index = treeBuilder.GetNode(op.Index);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the VectorExtractDynamic object.</summary>
        /// <returns>A string that represents the VectorExtractDynamic object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"VectorExtractDynamic({ResultType}, {Vector}, {Index}, {DebugName})";
        }
    }
}