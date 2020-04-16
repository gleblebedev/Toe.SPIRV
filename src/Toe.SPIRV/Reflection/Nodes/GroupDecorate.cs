using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupDecorate : ExecutableNode, INodeWithNext
    {
        public GroupDecorate()
        {
        }

        public override Op OpCode => Op.OpGroupDecorate;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

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
            SetUp((OpGroupDecorate)op, treeBuilder);
        }

        public void SetUp(OpGroupDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DecorationGroup = treeBuilder.GetNode(op.DecorationGroup);
            Targets = treeBuilder.GetNodes(op.Targets);
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}