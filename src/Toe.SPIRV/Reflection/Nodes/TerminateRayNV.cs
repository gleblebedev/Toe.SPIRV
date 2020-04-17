using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class TerminateRayNV : ExecutableNode, INodeWithNext
    {
        public TerminateRayNV()
        {
        }

        public override Op OpCode => Op.OpTerminateRayNV;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
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
            SetUp((OpTerminateRayNV)op, treeBuilder);
        }

        public void SetUp(OpTerminateRayNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}