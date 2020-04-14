using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class InBoundsPtrAccessChain : Node
    {
        public InBoundsPtrAccessChain()
        {
        }

        public override Op OpCode => Op.OpInBoundsPtrAccessChain;


        public Node Base { get; set; }
        public Node Element { get; set; }
        public IList<Node> Indexes { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
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

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield return new NodePin(this, "", ResultType);
                yield break;
            }
        }


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpInBoundsPtrAccessChain)op, treeBuilder);
        }

        public void SetUp(OpInBoundsPtrAccessChain op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Base = treeBuilder.GetNode(op.Base);
            Element = treeBuilder.GetNode(op.Element);
            Indexes = treeBuilder.GetNodes(op.Indexes);
        }
    }
}