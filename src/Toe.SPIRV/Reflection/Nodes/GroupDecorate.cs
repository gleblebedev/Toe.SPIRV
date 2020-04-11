using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupDecorate : SequentialOperationNode 
    {
        public GroupDecorate(OpGroupDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
            Targets = treeBuilder.GetNodes(op.Targets);
        }

        public Node DecorationGroup { get; set; }
        public IList<Node> Targets { get; set; }
    }
}