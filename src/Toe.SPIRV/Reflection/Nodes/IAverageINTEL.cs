using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class IAverageINTEL : Node
    {
        public IAverageINTEL()
        {
        }

        public IAverageINTEL(SpirvTypeBase resultType, Node operand1, Node operand2, string debugName = null)
        {
            this.ResultType = resultType;
            this.Operand1 = operand1;
            this.Operand2 = operand2;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpIAverageINTEL;

        public Node Operand1 { get; set; }

        public Node Operand2 { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<Node> GetInputNodes()
        {
                yield return Operand1;
                yield return Operand2;
        }

        public IAverageINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpIAverageINTEL)op, treeBuilder);
        }

        public IAverageINTEL SetUp(Action<IAverageINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpIAverageINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Operand1 = treeBuilder.GetNode(op.Operand1);
            Operand2 = treeBuilder.GetNode(op.Operand2);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the IAverageINTEL object.</summary>
        /// <returns>A string that represents the IAverageINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"IAverageINTEL({ResultType}, {Operand1}, {Operand2}, {DebugName})";
        }
    }
}