using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public class Branch : SequentialOperationNode
    {
        public Branch(OpBranch op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public new Label Next
        {
            get => (Label)base.Next;
            set => base.Next = value;
        }
    }
}