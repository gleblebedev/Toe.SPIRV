using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Select : Node
    {
        public Select()
        {
        }

        public Select(SpirvTypeBase resultType, Node condition, Node object1, Node object2, string debugName = null)
        {
            this.ResultType = resultType;
            this.Condition = condition;
            this.Object1 = object1;
            this.Object2 = object2;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSelect;

        public Node Condition { get; set; }

        public Node Object1 { get; set; }

        public Node Object2 { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Condition), Condition);
                yield return CreateInputPin(nameof(Object1), Object1);
                yield return CreateInputPin(nameof(Object2), Object2);
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

        public Select WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSelect)op, treeBuilder);
        }

        public Select SetUp(Action<Select> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSelect op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Condition = treeBuilder.GetNode(op.Condition);
            Object1 = treeBuilder.GetNode(op.Object1);
            Object2 = treeBuilder.GetNode(op.Object2);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Select object.</summary>
        /// <returns>A string that represents the Select object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Select({ResultType}, {Condition}, {Object1}, {Object2}, {DebugName})";
        }
    }
}