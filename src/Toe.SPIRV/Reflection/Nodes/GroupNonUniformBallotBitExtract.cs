using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupNonUniformBallotBitExtract : Node
    {
        public GroupNonUniformBallotBitExtract()
        {
        }

        public override Op OpCode => Op.OpGroupNonUniformBallotBitExtract;


        public uint Execution { get; set; }
        public Node Value { get; set; }
        public Node Index { get; set; }
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
                yield return CreateInputPin(nameof(Value), Value);
                yield return CreateInputPin(nameof(Index), Index);
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
            SetUp((OpGroupNonUniformBallotBitExtract)op, treeBuilder);
        }

        public void SetUp(OpGroupNonUniformBallotBitExtract op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Value = treeBuilder.GetNode(op.Value);
            Index = treeBuilder.GetNode(op.Index);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}