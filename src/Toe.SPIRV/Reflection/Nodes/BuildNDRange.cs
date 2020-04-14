using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BuildNDRange : FunctionNode 
    {
        public BuildNDRange()
        {
        }

        public Node GlobalWorkSize { get; set; }
        public Node LocalWorkSize { get; set; }
        public Node GlobalWorkOffset { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(GlobalWorkSize), GlobalWorkSize);
                yield return CreateInputPin(nameof(LocalWorkSize), LocalWorkSize);
                yield return CreateInputPin(nameof(GlobalWorkOffset), GlobalWorkOffset);
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
            SetUp((OpBuildNDRange)op, treeBuilder);
        }

        public void SetUp(OpBuildNDRange op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            GlobalWorkSize = treeBuilder.GetNode(op.GlobalWorkSize);
            LocalWorkSize = treeBuilder.GetNode(op.LocalWorkSize);
            GlobalWorkOffset = treeBuilder.GetNode(op.GlobalWorkOffset);
        }
    }
}