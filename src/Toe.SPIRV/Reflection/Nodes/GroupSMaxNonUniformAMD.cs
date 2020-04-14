using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupSMaxNonUniformAMD : Node
    {
        public GroupSMaxNonUniformAMD()
        {
        }

        public override Op OpCode => Op.OpGroupSMaxNonUniformAMD;


        public uint Execution { get; set; }
        public Spv.GroupOperation Operation { get; set; }
        public Node X { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(X), X);
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
            SetUp((OpGroupSMaxNonUniformAMD)op, treeBuilder);
        }

        public void SetUp(OpGroupSMaxNonUniformAMD op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Operation = op.Operation;
            X = treeBuilder.GetNode(op.X);
        }
    }
}