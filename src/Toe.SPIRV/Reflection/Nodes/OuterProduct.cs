using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class OuterProduct : Node
    {
        public OuterProduct()
        {
        }

        public override Op OpCode => Op.OpOuterProduct;


        public Node Vector1 { get; set; }
        public Node Vector2 { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Vector1), Vector1);
                yield return CreateInputPin(nameof(Vector2), Vector2);
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
            SetUp((OpOuterProduct)op, treeBuilder);
        }

        public void SetUp(OpOuterProduct op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Vector1 = treeBuilder.GetNode(op.Vector1);
            Vector2 = treeBuilder.GetNode(op.Vector2);
        }
    }
}