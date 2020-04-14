using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BitFieldInsert : Node
    {
        public BitFieldInsert()
        {
        }

        public override Op OpCode => Op.OpBitFieldInsert;


        public Node Base { get; set; }
        public Node Insert { get; set; }
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
                yield return CreateInputPin(nameof(Insert), Insert);
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
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpBitFieldInsert)op, treeBuilder);
        }

        public void SetUp(OpBitFieldInsert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Insert = treeBuilder.GetNode(op.Insert);
            Offset = treeBuilder.GetNode(op.Offset);
            Count = treeBuilder.GetNode(op.Count);
        }
    }
}