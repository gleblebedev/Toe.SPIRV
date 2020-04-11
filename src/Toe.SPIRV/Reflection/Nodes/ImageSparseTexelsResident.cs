using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSparseTexelsResident : FunctionNode 
    {
        public ImageSparseTexelsResident(OpImageSparseTexelsResident op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(op.IdResultType);
            ResidentCode = treeBuilder.GetNode(op.ResidentCode);
        }

        public Node ResidentCode { get; set; }
    }
}