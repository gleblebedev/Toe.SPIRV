using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SpecConstantOp : FunctionNode 
    {
        public SpecConstantOp(OpSpecConstantOp op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Operands = treeBuilder.GetNodes(op.Operands);
        }

        public IList<Node> Operands { get; set; }
    }
}