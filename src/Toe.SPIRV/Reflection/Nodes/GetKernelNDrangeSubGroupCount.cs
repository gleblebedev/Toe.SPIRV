using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GetKernelNDrangeSubGroupCount : Node
    {
        public GetKernelNDrangeSubGroupCount()
        {
        }

        public GetKernelNDrangeSubGroupCount(SpirvTypeBase resultType, Node nDRange, Node invoke, Node param, Node paramSize, Node paramAlign, string debugName = null)
        {
            this.ResultType = resultType;
            this.NDRange = nDRange;
            this.Invoke = invoke;
            this.Param = param;
            this.ParamSize = paramSize;
            this.ParamAlign = paramAlign;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGetKernelNDrangeSubGroupCount;

        public Node NDRange { get; set; }

        public Node Invoke { get; set; }

        public Node Param { get; set; }

        public Node ParamSize { get; set; }

        public Node ParamAlign { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(NDRange), NDRange);
                yield return CreateInputPin(nameof(Invoke), Invoke);
                yield return CreateInputPin(nameof(Param), Param);
                yield return CreateInputPin(nameof(ParamSize), ParamSize);
                yield return CreateInputPin(nameof(ParamAlign), ParamAlign);
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

        public GetKernelNDrangeSubGroupCount WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGetKernelNDrangeSubGroupCount)op, treeBuilder);
        }

        public GetKernelNDrangeSubGroupCount SetUp(Action<GetKernelNDrangeSubGroupCount> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGetKernelNDrangeSubGroupCount op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            NDRange = treeBuilder.GetNode(op.NDRange);
            Invoke = treeBuilder.GetNode(op.Invoke);
            Param = treeBuilder.GetNode(op.Param);
            ParamSize = treeBuilder.GetNode(op.ParamSize);
            ParamAlign = treeBuilder.GetNode(op.ParamAlign);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GetKernelNDrangeSubGroupCount object.</summary>
        /// <returns>A string that represents the GetKernelNDrangeSubGroupCount object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GetKernelNDrangeSubGroupCount({ResultType}, {NDRange}, {Invoke}, {Param}, {ParamSize}, {ParamAlign}, {DebugName})";
        }
    }
}