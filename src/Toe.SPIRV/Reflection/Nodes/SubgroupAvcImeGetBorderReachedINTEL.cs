using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeGetBorderReachedINTEL : Node
    {
        public SubgroupAvcImeGetBorderReachedINTEL()
        {
        }

        public SubgroupAvcImeGetBorderReachedINTEL(SpirvTypeBase resultType, Node imageSelect, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.ImageSelect = imageSelect;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeGetBorderReachedINTEL;

        public Node ImageSelect { get; set; }

        public Node Payload { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(ImageSelect), ImageSelect);
                yield return CreateInputPin(nameof(Payload), Payload);
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

        public SubgroupAvcImeGetBorderReachedINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeGetBorderReachedINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeGetBorderReachedINTEL SetUp(Action<SubgroupAvcImeGetBorderReachedINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeGetBorderReachedINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            ImageSelect = treeBuilder.GetNode(op.ImageSelect);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeGetBorderReachedINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeGetBorderReachedINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeGetBorderReachedINTEL({ResultType}, {ImageSelect}, {Payload}, {DebugName})";
        }
    }
}