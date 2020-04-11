using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public class Label : SequentialOperationNode
    {
        public Label(OpLabel op, SpirvInstructionTreeBuilder context)
        {
            Name = op.OpName?.Name;
        }
        public string Name { get; }

        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}