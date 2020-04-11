using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConvertFToS : FunctionNode 
    {
        public ConvertFToS(OpConvertFToS op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            FloatValue = treeBuilder.GetNode(op.FloatValue);
        }

        public Node FloatValue { get; set; }
    }
}