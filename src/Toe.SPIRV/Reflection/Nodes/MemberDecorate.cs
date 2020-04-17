using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorate : ExecutableNode, INodeWithNext
    {
        public MemberDecorate()
        {
        }

        public override Op OpCode => Op.OpMemberDecorate;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public SpirvTypeBase StructureType { get; set; }
        public uint Member { get; set; }
        public Spv.Decoration Decoration { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> EnterPins
        {
            get
            {
                yield return new NodePin(this, "", null);
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpMemberDecorate)op, treeBuilder);
        }

        public void SetUp(OpMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructureType = treeBuilder.ResolveType(op.StructureType);
            Member = op.Member;
            Decoration = op.Decoration;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}