using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public class BranchConditional : SequentialOperationNode
    {
        public BranchConditional(OpBranchConditional op, SpirvInstructionTreeBuilder treeBuilder)
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

        public Label TrueLabel { get; set; }

        public Label FalseLabel { get; set; }

        public override void FixForwardReferences(Instruction instruction, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.FixForwardReferences(instruction, treeBuilder);
            TrueLabel = (Label)treeBuilder.GetNode(((OpBranchConditional)instruction).TrueLabel);
            FalseLabel = (Label)treeBuilder.GetNode(((OpBranchConditional)instruction).FalseLabel);
        }
    }
}