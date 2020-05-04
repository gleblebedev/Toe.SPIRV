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

        public ConstantSampler(SpirvTypeBase resultType, Spv.SamplerAddressingMode samplerAddressingMode, uint param, Spv.SamplerFilterMode samplerFilterMode, string debugName = null)
        {
            this.ResultType = resultType;
            this.SamplerAddressingMode = samplerAddressingMode;
            this.Param = param;
            this.SamplerFilterMode = samplerFilterMode;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpConstantSampler;

        public Spv.SamplerAddressingMode SamplerAddressingMode { get; set; }

        public uint Param { get; set; }

        public Spv.SamplerFilterMode SamplerFilterMode { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public ConstantSampler WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpConstantSampler)op, treeBuilder);
        }

        public ConstantSampler SetUp(Action<ConstantSampler> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpConstantSampler op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SamplerAddressingMode = op.SamplerAddressingMode;
            Param = op.Param;
            SamplerFilterMode = op.SamplerFilterMode;
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the ConstantSampler object.</summary>
        /// <returns>A string that represents the ConstantSampler object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"ConstantSampler({ResultType}, {SamplerAddressingMode}, {Param}, {SamplerFilterMode}, {DebugName})";
        }
    }
}