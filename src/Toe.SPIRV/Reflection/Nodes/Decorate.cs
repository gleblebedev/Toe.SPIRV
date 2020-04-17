using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Decorate : ExecutableNode, INodeWithNext
    {
        public Decorate()
        {
        }

        public override Op OpCode => Op.OpDecorate;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public ReflectedInstruction Target { get; set; }
        public Spv.Decoration Decoration { get; set; }

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
            SetUp((OpDecorate)op, treeBuilder);
        }

        public void SetUp(OpDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.ResolveType(op.Target);
            Decoration = op.Decoration;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}