using System.Collections.Generic;
using System.Linq;

namespace Toe.SPIRV.Reflection.Nodes
{

    public abstract class ExecutableNode: Node
    {
        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public Node Next { get; set; }

        public override Node GetNext()
        {
            return Next;
        }
    }
}