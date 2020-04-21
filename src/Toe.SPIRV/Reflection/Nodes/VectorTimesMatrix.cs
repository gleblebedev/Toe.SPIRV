using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class VectorTimesMatrix : Node
    {
        public VectorTimesMatrix()
        {
        }

        public VectorTimesMatrix(SpirvTypeBase resultType, Node vector, Node matrix, string debugName = null)
        {
            this.ResultType = resultType;
            this.Vector = vector;
            this.Matrix = matrix;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpVectorTimesMatrix;

        public Node Vector { get; set; }

        public Node Matrix { get; set; }

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
                yield return CreateInputPin(nameof(Matrix), Matrix);
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

        public VectorTimesMatrix WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpVectorTimesMatrix)op, treeBuilder);
        }

        public VectorTimesMatrix SetUp(Action<VectorTimesMatrix> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpVectorTimesMatrix op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector = treeBuilder.GetNode(op.Vector);
            Matrix = treeBuilder.GetNode(op.Matrix);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the VectorTimesMatrix object.</summary>
        /// <returns>A string that represents the VectorTimesMatrix object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"VectorTimesMatrix({ResultType}, {Vector}, {Matrix}, {DebugName})";
        }
    }
}