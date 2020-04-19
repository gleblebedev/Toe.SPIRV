using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupDecorate : Node
    {
        public GroupDecorate()
        {
        }

        public override Op OpCode => Op.OpGroupDecorate;


        public Node DecorationGroup { get; set; }
        public IList<Node> Targets { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(DecorationGroup), DecorationGroup);
                for (var index = 0; index < Targets.Count; index++)
                {
                    yield return CreateInputPin(nameof(Targets) + index, Targets[index]);
                }
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
            SetUp((OpGroupDecorate)op, treeBuilder);
        }

        public void SetUp(OpGroupDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
            Targets = treeBuilder.GetNodes(op.Targets);
            SetUpDecorations(op, treeBuilder);
        }
    }
}