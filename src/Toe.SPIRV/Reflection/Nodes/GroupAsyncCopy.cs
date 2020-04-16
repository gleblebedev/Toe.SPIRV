using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupAsyncCopy : Node
    {
        public GroupAsyncCopy()
        {
        }

        public override Op OpCode => Op.OpGroupAsyncCopy;


        public uint Execution { get; set; }
        public Node Destination { get; set; }
        public Node Source { get; set; }
        public Node NumElements { get; set; }
        public Node Stride { get; set; }
        public Node Event { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Destination), Destination);
                yield return CreateInputPin(nameof(Source), Source);
                yield return CreateInputPin(nameof(NumElements), NumElements);
                yield return CreateInputPin(nameof(Stride), Stride);
                yield return CreateInputPin(nameof(Event), Event);
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
            SetUp((OpGroupAsyncCopy)op, treeBuilder);
        }

        public void SetUp(OpGroupAsyncCopy op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Destination = treeBuilder.GetNode(op.Destination);
            Source = treeBuilder.GetNode(op.Source);
            NumElements = treeBuilder.GetNode(op.NumElements);
            Stride = treeBuilder.GetNode(op.Stride);
            Event = treeBuilder.GetNode(op.Event);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}