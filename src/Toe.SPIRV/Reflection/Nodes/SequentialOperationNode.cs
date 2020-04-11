using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{

    public abstract class SequentialOperationNode: Node
    {
        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public Node Next { get; set; }
    }
}