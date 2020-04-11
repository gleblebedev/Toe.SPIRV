using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ShiftLeftLogical : FunctionNode 
    {
        public ShiftLeftLogical(OpShiftLeftLogical op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Shift = treeBuilder.GetNode(op.Shift);
        }

        public Node Base { get; set; }
        public Node Shift { get; set; }
    }
}