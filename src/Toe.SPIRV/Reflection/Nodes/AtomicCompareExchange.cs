using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicCompareExchange : Node
    {
        public AtomicCompareExchange()
        {
        }

        public override Op OpCode => Op.OpAtomicCompareExchange;


        public Node Pointer { get; set; }
        public uint Scope { get; set; }
        public uint Equal { get; set; }
        public uint Unequal { get; set; }
        public Node Value { get; set; }
        public Node Comparator { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
                yield return CreateInputPin(nameof(Value), Value);
                yield return CreateInputPin(nameof(Comparator), Comparator);
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
            SetUp((OpAtomicCompareExchange)op, treeBuilder);
        }

        public void SetUp(OpAtomicCompareExchange op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            Scope = op.Scope;
            Equal = op.Equal;
            Unequal = op.Unequal;
            Value = treeBuilder.GetNode(op.Value);
            Comparator = treeBuilder.GetNode(op.Comparator);
        }
    }
}