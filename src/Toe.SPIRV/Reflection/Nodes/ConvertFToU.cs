using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConvertFToU : FunctionNode 
    {
        public ConvertFToU(OpConvertFToU op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            FloatValue = treeBuilder.GetNode(op.FloatValue);
        }

        public Node FloatValue { get; set; }
    }
}