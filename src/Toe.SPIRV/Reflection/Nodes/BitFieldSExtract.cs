using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BitFieldSExtract : Node
    {
        public BitFieldSExtract()
        {
        }

        public BitFieldSExtract(SpirvTypeBase resultType, Node @base, Node offset, Node count, string debugName = null)
        {
            this.ResultType = resultType;
            this.Base = @base;
            this.Offset = offset;
            this.Count = count;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpBitFieldSExtract;

        public Node Base { get; set; }

        public Node Offset { get; set; }

        public Node Count { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Base), Base);
                yield return CreateInputPin(nameof(Offset), Offset);
                yield return CreateInputPin(nameof(Count), Count);
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

        public BitFieldSExtract WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpBitFieldSExtract)op, treeBuilder);
        }

        public BitFieldSExtract SetUp(Action<BitFieldSExtract> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpBitFieldSExtract op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Offset = treeBuilder.GetNode(op.Offset);
            Count = treeBuilder.GetNode(op.Count);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the BitFieldSExtract object.</summary>
        /// <returns>A string that represents the BitFieldSExtract object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"BitFieldSExtract({ResultType}, {Base}, {Offset}, {Count}, {DebugName})";
        }
    }
}