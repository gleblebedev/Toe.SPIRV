using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageQuerySizeLod : FunctionNode 
    {
        public ImageQuerySizeLod()
        {
        }

        public Node Image { get; set; }
        public Node LevelofDetail { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(LevelofDetail), LevelofDetail);
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
            SetUp((OpImageQuerySizeLod)op, treeBuilder);
        }

        public void SetUp(OpImageQuerySizeLod op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            LevelofDetail = treeBuilder.GetNode(op.LevelofDetail);
        }
    }
}