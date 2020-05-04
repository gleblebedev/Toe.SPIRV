using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AbsISubINTEL : Node
    {
        public AbsISubINTEL()
        {
        }

        public AbsISubINTEL(SpirvTypeBase resultType, Node operand1, Node operand2, string debugName = null)
        {
            this.ResultType = resultType;
            this.Operand1 = operand1;
            this.Operand2 = operand2;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpAbsISubINTEL;

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

        public AbsISubINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpAbsISubINTEL)op, treeBuilder);
        }

        public AbsISubINTEL SetUp(Action<AbsISubINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpAbsISubINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Operand1 = treeBuilder.GetNode(op.Operand1);
            Operand2 = treeBuilder.GetNode(op.Operand2);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the AbsISubINTEL object.</summary>
        /// <returns>A string that represents the AbsISubINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"AbsISubINTEL({ResultType}, {Operand1}, {Operand2}, {DebugName})";
        }
    }
}