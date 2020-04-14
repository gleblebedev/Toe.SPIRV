using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FragmentFetchAMD : FunctionNode 
    {
        public FragmentFetchAMD()
        {
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node FragmentIndex { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(FragmentIndex), FragmentIndex);
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
            SetUp((OpFragmentFetchAMD)op, treeBuilder);
        }

        public void SetUp(OpFragmentFetchAMD op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            FragmentIndex = treeBuilder.GetNode(op.FragmentIndex);
        }
    }
}