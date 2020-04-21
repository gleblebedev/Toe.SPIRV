using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcSicInitializeINTEL : Node
    {
        public SubgroupAvcSicInitializeINTEL()
        {
        }

        public SubgroupAvcSicInitializeINTEL(SpirvTypeBase resultType, Node srcCoord, string debugName = null)
        {
            this.ResultType = resultType;
            this.SrcCoord = srcCoord;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcSicInitializeINTEL;

        public Node SrcCoord { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SrcCoord), SrcCoord);
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

        public SubgroupAvcSicInitializeINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcSicInitializeINTEL)op, treeBuilder);
        }

        public SubgroupAvcSicInitializeINTEL SetUp(Action<SubgroupAvcSicInitializeINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcSicInitializeINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcCoord = treeBuilder.GetNode(op.SrcCoord);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcSicInitializeINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcSicInitializeINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcSicInitializeINTEL({ResultType}, {SrcCoord}, {DebugName})";
        }
    }
}