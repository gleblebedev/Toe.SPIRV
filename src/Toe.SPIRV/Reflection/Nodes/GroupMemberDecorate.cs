using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupMemberDecorate : Node
    {
        public GroupMemberDecorate()
        {
        }

        public override Op OpCode => Op.OpGroupMemberDecorate;


        public Node DecorationGroup { get; set; }
        public IList<Operands.PairNodeLiteralInteger> Targets { get; } = new List<Operands.PairNodeLiteralInteger>();
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(DecorationGroup), DecorationGroup);
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
            SetUp((OpGroupMemberDecorate)op, treeBuilder);
        }

        public void SetUp(OpGroupMemberDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
            foreach (var item in op.Targets) { Targets.Add(treeBuilder.Parse(item)); }
            SetUpDecorations(op, treeBuilder);
        }
    }
}