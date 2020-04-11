using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorateStringGOOGLE : SequentialOperationNode 
    {
        public MemberDecorateStringGOOGLE(OpMemberDecorateStringGOOGLE op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructType = treeBuilder.GetNode(op.StructType);
        }

        public Node StructType { get; set; }
    }
}