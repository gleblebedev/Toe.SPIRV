using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ExtInst : Node
    {
        public ExtInst()
        {
        }

        public override Op OpCode => Op.OpExtInst;


        public Node Set { get; set; }
        public uint Instruction { get; set; }
        public IList<Node> Operands { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Set), Set);
                for (var index = 0; index < Operands.Count; index++)
                {
                    yield return CreateInputPin(nameof(Operands) + index, Operands[index]);
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
            SetUp((OpExtInst)op, treeBuilder);
        }

        public void SetUp(OpExtInst op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Set = treeBuilder.GetNode(op.Set);
            Instruction = op.Instruction;
            Operands = treeBuilder.GetNodes(op.Operands);
            SetUpDecorations(op.Decorations);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}