using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BuildNDRange : FunctionNode 
    {
        public BuildNDRange(OpBuildNDRange op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            GlobalWorkSize = treeBuilder.GetNode(op.GlobalWorkSize);
            LocalWorkSize = treeBuilder.GetNode(op.LocalWorkSize);
            GlobalWorkOffset = treeBuilder.GetNode(op.GlobalWorkOffset);
        }

        public Node GlobalWorkSize { get; set; }
        public Node LocalWorkSize { get; set; }
        public Node GlobalWorkOffset { get; set; }
    }
}