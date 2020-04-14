using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageSparseTexelsResident : FunctionNode 
    {
        public ImageSparseTexelsResident()
        {
        }

        public Node ResidentCode { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(ResidentCode), ResidentCode);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpImageSparseTexelsResident)op, treeBuilder);
        }

        public void SetUp(OpImageSparseTexelsResident op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            ResidentCode = treeBuilder.GetNode(op.ResidentCode);
        }
    }
}