using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FragmentFetchAMD : FunctionNode 
    {
        public FragmentFetchAMD(OpFragmentFetchAMD op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            FragmentIndex = treeBuilder.GetNode(op.FragmentIndex);
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node FragmentIndex { get; set; }
    }
}