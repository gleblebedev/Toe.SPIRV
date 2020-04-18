using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupImageMediaBlockReadINTEL : Node
    {
        public SubgroupImageMediaBlockReadINTEL()
        {
        }

        public override Op OpCode => Op.OpSubgroupImageMediaBlockReadINTEL;


        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Width { get; set; }
        public Node Height { get; set; }
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
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(Width), Width);
                yield return CreateInputPin(nameof(Height), Height);
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
            SetUp((OpSubgroupImageMediaBlockReadINTEL)op, treeBuilder);
        }

        public void SetUp(OpSubgroupImageMediaBlockReadINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Width = treeBuilder.GetNode(op.Width);
            Height = treeBuilder.GetNode(op.Height);
            SetUpDecorations(op, treeBuilder);
        }
    }
}