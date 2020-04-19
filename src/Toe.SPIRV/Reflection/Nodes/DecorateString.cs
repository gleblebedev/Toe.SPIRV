using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class DecorateString : Node
    {
        public DecorateString()
        {
        }

        public override Op OpCode => Op.OpDecorateString;


        public Node Target { get; set; }
        public Spv.Decoration Decoration { get; set; }

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
                yield return CreateExitPin(nameof(Target), Target);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpDecorateString)op, treeBuilder);
        }

        public void SetUp(OpDecorateString op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Decoration = op.Decoration;
            SetUpDecorations(op, treeBuilder);
        }
    }
}