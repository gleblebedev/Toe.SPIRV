using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class PtrAccessChain : FunctionNode 
    {
        public PtrAccessChain()
        {
        }

        public Node Base { get; set; }
        public Node Element { get; set; }
        public IList<Node> Indexes { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Base), Base);
                yield return CreateInputPin(nameof(Element), Element);
                for (var index = 0; index < Indexes.Count; index++)
                {
                    yield return CreateInputPin(nameof(Indexes) + index, Indexes[index]);
                }
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
            SetUp((OpPtrAccessChain)op, treeBuilder);
        }

        public void SetUp(OpPtrAccessChain op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Element = treeBuilder.GetNode(op.Element);
            Indexes = treeBuilder.GetNodes(op.Indexes);
        }
    }
}