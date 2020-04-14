using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ImageWrite : ExecutableNode 
    {
        public ImageWrite()
        {
        }

        public Node Image { get; set; }
        public Node Coordinate { get; set; }
        public Node Texel { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(Texel), Texel);
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
            SetUp((OpImageWrite)op, treeBuilder);
        }

        public void SetUp(OpImageWrite op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Texel = treeBuilder.GetNode(op.Texel);
        }
    }
}