using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupAsyncCopy : FunctionNode 
    {
        public GroupAsyncCopy()
        {
        }

        public Node Destination { get; set; }
        public Node Source { get; set; }
        public Node NumElements { get; set; }
        public Node Stride { get; set; }
        public Node Event { get; set; }
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

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
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
            Destination = treeBuilder.GetNode(op.Destination);
            Source = treeBuilder.GetNode(op.Source);
            NumElements = treeBuilder.GetNode(op.NumElements);
            Stride = treeBuilder.GetNode(op.Stride);
            Event = treeBuilder.GetNode(op.Event);
        }
    }
}