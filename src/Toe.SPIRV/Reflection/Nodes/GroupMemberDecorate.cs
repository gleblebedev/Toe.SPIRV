using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupMemberDecorate : SequentialOperationNode 
    {
        public GroupMemberDecorate(OpGroupMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
        }

        public Node DecorationGroup { get; set; }
    }
}