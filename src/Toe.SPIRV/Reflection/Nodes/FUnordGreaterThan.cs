using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FUnordGreaterThan : Node
    {
        public FUnordGreaterThan()
        {
        }

        public FUnordGreaterThan(SpirvTypeBase resultType, Node operand1, Node operand2, string debugName = null)
        {
            this.ResultType = resultType;
            this.Operand1 = operand1;
            this.Operand2 = operand2;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpFUnordGreaterThan;

        public Node Operand1 { get; set; }

        public Node Operand2 { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Operand1), Operand1);
                yield return CreateInputPin(nameof(Operand2), Operand2);
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

        public FUnordGreaterThan WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpFUnordGreaterThan)op, treeBuilder);
        }

        public FUnordGreaterThan SetUp(Action<FUnordGreaterThan> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpFUnordGreaterThan op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Operand1 = treeBuilder.GetNode(op.Operand1);
            Operand2 = treeBuilder.GetNode(op.Operand2);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the FUnordGreaterThan object.</summary>
        /// <returns>A string that represents the FUnordGreaterThan object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"FUnordGreaterThan({ResultType}, {Operand1}, {Operand2}, {DebugName})";
        }
    }
}