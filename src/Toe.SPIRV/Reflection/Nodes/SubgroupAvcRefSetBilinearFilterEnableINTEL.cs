using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcRefSetBilinearFilterEnableINTEL : Node
    {
        public SubgroupAvcRefSetBilinearFilterEnableINTEL()
        {
        }

        public SubgroupAvcRefSetBilinearFilterEnableINTEL(SpirvTypeBase resultType, Node payload, string debugName = null)
        {
            this.ResultType = resultType;
            this.Payload = payload;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcRefSetBilinearFilterEnableINTEL;

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

        public SubgroupAvcRefSetBilinearFilterEnableINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcRefSetBilinearFilterEnableINTEL)op, treeBuilder);
        }

        public SubgroupAvcRefSetBilinearFilterEnableINTEL SetUp(Action<SubgroupAvcRefSetBilinearFilterEnableINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcRefSetBilinearFilterEnableINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Payload = treeBuilder.GetNode(op.Payload);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcRefSetBilinearFilterEnableINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcRefSetBilinearFilterEnableINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcRefSetBilinearFilterEnableINTEL({ResultType}, {Payload}, {DebugName})";
        }
    }
}