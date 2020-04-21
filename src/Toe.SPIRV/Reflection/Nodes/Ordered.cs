using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Ordered : Node
    {
        public Ordered()
        {
        }

        public Ordered(SpirvTypeBase resultType, Node x, Node y, string debugName = null)
        {
            this.ResultType = resultType;
            this.x = x;
            this.y = y;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpOrdered;

        public Node x { get; set; }

        public Node y { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(x), x);
                yield return CreateInputPin(nameof(y), y);
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

        public Ordered WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpOrdered)op, treeBuilder);
        }

        public Ordered SetUp(Action<Ordered> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpOrdered op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            x = treeBuilder.GetNode(op.x);
            y = treeBuilder.GetNode(op.y);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Ordered object.</summary>
        /// <returns>A string that represents the Ordered object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Ordered({ResultType}, {x}, {y}, {DebugName})";
        }
    }
}