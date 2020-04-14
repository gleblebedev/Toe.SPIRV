using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class BitFieldSExtract : FunctionNode 
    {
        public BitFieldSExtract()
        {
        }

        public Node Base { get; set; }
        public Node Offset { get; set; }
        public Node Count { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Base), Base);
                yield return CreateInputPin(nameof(Offset), Offset);
                yield return CreateInputPin(nameof(Count), Count);
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
            SetUp((OpBitFieldSExtract)op, treeBuilder);
        }

        public void SetUp(OpBitFieldSExtract op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Offset = treeBuilder.GetNode(op.Offset);
            Count = treeBuilder.GetNode(op.Count);
        }
    }
}