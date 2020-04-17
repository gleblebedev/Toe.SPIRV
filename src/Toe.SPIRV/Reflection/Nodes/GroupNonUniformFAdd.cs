using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupNonUniformFAdd : Node
    {
        public GroupNonUniformFAdd()
        {
        }

        public override Op OpCode => Op.OpGroupNonUniformFAdd;


        public uint Execution { get; set; }
        public Spv.GroupOperation Operation { get; set; }
        public Node Value { get; set; }
        public Node ClusterSize { get; set; }
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
                yield return CreateInputPin(nameof(ClusterSize), ClusterSize);
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
            SetUp((OpGroupNonUniformFAdd)op, treeBuilder);
        }

        public void SetUp(OpGroupNonUniformFAdd op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Operation = op.Operation;
            Value = treeBuilder.GetNode(op.Value);
            ClusterSize = treeBuilder.GetNode(op.ClusterSize);
            RelaxedPrecision = op.Decorations.Any(_ => _.Decoration.Value == Decoration.Enumerant.RelaxedPrecision);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}