using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorTimesScalar : Node
    {
        public VectorTimesScalar()
        {
        }

        public VectorTimesScalar(SpirvTypeBase resultType, Node vector, Node scalar, string debugName = null)
        {
            this.ResultType = resultType;
            this.Vector = vector;
            this.Scalar = scalar;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpVectorTimesScalar;

        public Node Vector { get; set; }

        public Node Scalar { get; set; }

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
                yield return CreateInputPin(nameof(Scalar), Scalar);
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

        public VectorTimesScalar WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpVectorTimesScalar)op, treeBuilder);
        }

        public VectorTimesScalar SetUp(Action<VectorTimesScalar> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpVectorTimesScalar op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Scalar = treeBuilder.GetNode(op.Scalar);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the VectorTimesScalar object.</summary>
        /// <returns>A string that represents the VectorTimesScalar object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"VectorTimesScalar({ResultType}, {Vector}, {Scalar}, {DebugName})";
        }
    }
}