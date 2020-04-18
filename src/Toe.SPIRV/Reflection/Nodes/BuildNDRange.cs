using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BuildNDRange : Node
    {
        public BuildNDRange()
        {
        }

        public override Op OpCode => Op.OpBuildNDRange;


        public Node GlobalWorkSize { get; set; }
        public Node LocalWorkSize { get; set; }
        public Node GlobalWorkOffset { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public bool RelaxedPrecision { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(GlobalWorkSize), GlobalWorkSize);
                yield return CreateInputPin(nameof(LocalWorkSize), LocalWorkSize);
                yield return CreateInputPin(nameof(GlobalWorkOffset), GlobalWorkOffset);
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
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpBuildNDRange)op, treeBuilder);
        }

        public void SetUp(OpBuildNDRange op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            GlobalWorkSize = treeBuilder.GetNode(op.GlobalWorkSize);
            LocalWorkSize = treeBuilder.GetNode(op.LocalWorkSize);
            GlobalWorkOffset = treeBuilder.GetNode(op.GlobalWorkOffset);
            SetUpDecorations(op, treeBuilder);
        }
    }
}