using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CompositeInsert : Node
    {
        public CompositeInsert()
        {
        }

        public override Op OpCode => Op.OpCompositeInsert;


        public Node Object { get; set; }
        public Node Composite { get; set; }
        public IList<uint> Indexes { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Object), Object);
                yield return CreateInputPin(nameof(Composite), Composite);
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
            SetUp((OpCompositeInsert)op, treeBuilder);
        }

        public void SetUp(OpCompositeInsert op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Object = treeBuilder.GetNode(op.Object);
            Composite = treeBuilder.GetNode(op.Composite);
            Indexes = op.Indexes;
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}