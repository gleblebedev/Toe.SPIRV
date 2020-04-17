using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberName : Node
    {
        public MemberName()
        {
        }

        public override Op OpCode => Op.OpMemberName;


        public SpirvTypeBase Type { get; set; }
        public uint Member { get; set; }
        public string Name { get; set; }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
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
            SetUp((OpMemberName)op, treeBuilder);
        }

        public void SetUp(OpMemberName op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Type = treeBuilder.ResolveType(op.Type);
            Member = op.Member;
            Name = op.Name;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}