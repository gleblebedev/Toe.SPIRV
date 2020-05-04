using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class UCountLeadingZerosINTEL : Node
    {
        public UCountLeadingZerosINTEL()
        {
        }

        public UCountLeadingZerosINTEL(SpirvTypeBase resultType, Node operand, string debugName = null)
        {
            this.ResultType = resultType;
            this.Operand = operand;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpUCountLeadingZerosINTEL;

        public Node Operand { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<Node> GetInputNodes()
        {
                yield return Operand;
        }

        public UCountLeadingZerosINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpUCountLeadingZerosINTEL)op, treeBuilder);
        }

        public UCountLeadingZerosINTEL SetUp(Action<UCountLeadingZerosINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpUCountLeadingZerosINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Operand = treeBuilder.GetNode(op.Operand);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the UCountLeadingZerosINTEL object.</summary>
        /// <returns>A string that represents the UCountLeadingZerosINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"UCountLeadingZerosINTEL({ResultType}, {Operand}, {DebugName})";
        }
    }
}