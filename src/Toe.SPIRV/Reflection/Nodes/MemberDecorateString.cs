using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class MemberDecorateString : Node
    {
        public MemberDecorateString()
        {
        }

        public override Op OpCode => Op.OpMemberDecorateString;


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


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpMemberDecorateString)op, treeBuilder);
        }

        public void SetUp(OpMemberDecorateString op, SpirvInstructionTreeBuilder treeBuilder)
        {
            StructType = treeBuilder.GetNode(op.StructType);
            Member = op.Member;
            Decoration = op.Decoration;
            SetUpDecorations(op, treeBuilder);
        }
    }
}