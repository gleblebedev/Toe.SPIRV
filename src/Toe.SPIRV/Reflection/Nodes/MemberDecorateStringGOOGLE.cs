using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorateStringGOOGLE : ExecutableNode, INodeWithNext
    {
        public MemberDecorateStringGOOGLE()
        {
        }

        public override Op OpCode => Op.OpMemberDecorateStringGOOGLE;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node StructType { get; set; }
        public uint Member { get; set; }
        public Spv.Decoration Decoration { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(StructType), StructType);
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
            SetUp((OpMemberDecorateStringGOOGLE)op, treeBuilder);
        }

        public void SetUp(OpMemberDecorateStringGOOGLE op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructType = treeBuilder.GetNode(op.StructType);
            Member = op.Member;
            Decoration = op.Decoration;
        }
    }
}