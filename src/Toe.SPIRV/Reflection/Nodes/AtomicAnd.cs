using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class AtomicAnd : Node
    {
        public AtomicAnd()
        {
        }

        public override Op OpCode => Op.OpAtomicAnd;


        public Node Pointer { get; set; }
        public uint Scope { get; set; }
        public uint Semantics { get; set; }
        public Node Value { get; set; }
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
            SetUp((OpAtomicAnd)op, treeBuilder);
        }

        public void SetUp(OpAtomicAnd op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            Scope = op.Scope;
            Semantics = op.Semantics;
            Value = treeBuilder.GetNode(op.Value);
        }
    }
}