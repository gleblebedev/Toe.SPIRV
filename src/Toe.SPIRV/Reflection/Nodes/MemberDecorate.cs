using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorate : SequentialOperationNode 
    {
        public MemberDecorate(OpMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructureType = treeBuilder.GetNode(op.StructureType);
        }

        public Node StructureType { get; set; }
    }
}