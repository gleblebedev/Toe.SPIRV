using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConstantSampler : Node
    {
        public ConstantSampler()
        {
        }

        public override Op OpCode => Op.OpConstantSampler;


        public Spv.SamplerAddressingMode SamplerAddressingMode { get; set; }
        public uint Param { get; set; }
        public Spv.SamplerFilterMode SamplerFilterMode { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public bool RelaxedPrecision { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
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
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpConstantSampler)op, treeBuilder);
        }

        public void SetUp(OpConstantSampler op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SamplerAddressingMode = op.SamplerAddressingMode;
            Param = op.Param;
            SamplerFilterMode = op.SamplerFilterMode;
            SetUpDecorations(op, treeBuilder);
        }
    }
}