using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Switch : SequentialOperationNode 
    {
        public Switch(OpSwitch op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Selector = treeBuilder.GetNode(op.Selector);
            Default = treeBuilder.GetNode(op.Default);
        }

        public Node Selector { get; set; }
        public Node Default { get; set; }
    }
}