using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GetKernelPreferredWorkGroupSizeMultiple : FunctionNode 
    {
        public GetKernelPreferredWorkGroupSizeMultiple(OpGetKernelPreferredWorkGroupSizeMultiple op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            Invoke = treeBuilder.GetNode(op.Invoke);
            Param = treeBuilder.GetNode(op.Param);
            ParamSize = treeBuilder.GetNode(op.ParamSize);
            ParamAlign = treeBuilder.GetNode(op.ParamAlign);
        }

        public Node Invoke { get; set; }
        public Node Param { get; set; }
        public Node ParamSize { get; set; }
        public Node ParamAlign { get; set; }
    }
}